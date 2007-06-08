using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Common.Utilities;
using System.Threading;
using ClearCanvas.Dicom.DataStore;
using ClearCanvas.ImageViewer.Services.LocalDataStore;
using ClearCanvas.Common;
using ClearCanvas.Dicom;
using ClearCanvas.ImageViewer.Services;

namespace ClearCanvas.ImageViewer.Shreds.LocalDataStore
{
	internal sealed partial class LocalDataStoreService
	{
		internal class ReceivedFileProcessor
		{
			private class ReceivedFileImportInformation : DicomFileImporter.FileImportInformation
			{
				private string _sourceAETitle;

				public ReceivedFileImportInformation(string sourceFile, string sourceAETitle)
					: base(sourceFile, FileImportBehaviour.Move, BadFileBehaviour.Move)
				{
					_sourceAETitle = sourceAETitle;
				}

				public string SourceAETitle
				{
					get { return _sourceAETitle; }
				}
			}

			private class InternalReceiveProgressItem : ReceiveProgressItem
			{
				private string _terminalErrorMessage;

				public InternalReceiveProgressItem()
				{
					_terminalErrorMessage = null;	
				}

				public string TerminalErrorMessage
				{
					get { return _terminalErrorMessage; }
					set { _terminalErrorMessage = value; }
				}
			}

			private LocalDataStoreService _parent;
			private object _syncLock = new object();
			private List<InternalReceiveProgressItem> _receiveProgressItems;

			public ReceivedFileProcessor(LocalDataStoreService parent)
			{
				_receiveProgressItems = new List<InternalReceiveProgressItem>();
				
				_parent = parent;

				_parent.CancelEvent += new EventHandler<ItemEventArgs<CancelProgressItemInformation>>(OnCancel);
				_parent.RepublishEvent += new EventHandler(OnRepublish);
			}

			private void OnRepublish(object sender, EventArgs e)
			{
				lock (_syncLock)
				{
					foreach (InternalReceiveProgressItem item in _receiveProgressItems)
						LocalDataStoreActivityPublisher.Instance.ReceiveProgressChanged(item.Clone());
				}
			}

			private void OnCancel(object sender, ItemEventArgs<CancelProgressItemInformation> e)
			{
				CancelProgressItemInformation information = e.Item;

				if (information.ProgressItemIdentifiers == null)
					return;

				if (information.CancellationFlags != CancellationFlags.Clear)
					return;

				lock (_syncLock)
				{
					foreach (Guid identifier in information.ProgressItemIdentifiers)
					{
						InternalReceiveProgressItem item = _receiveProgressItems.Find(delegate(InternalReceiveProgressItem test) { return test.Identifier.Equals(identifier); });
						if (item != null)
						{
							_receiveProgressItems.Remove(item);

							item.Removed = true;
							LocalDataStoreActivityPublisher.Instance.ReceiveProgressChanged(item.Clone());
						}
					}
				}
			}

			private InternalReceiveProgressItem GetReceiveProgressItem(ReceivedFileImportInformation information, out bool exists)
			{
				StudyInformation studyInformation = new StudyInformation();
				studyInformation.PatientId = information.PatientId;
				studyInformation.PatientsName = information.PatientsName;
				
				DateTime date;
				DateParser.Parse(information.StudyDate, out date);
				studyInformation.StudyDate = date;

				studyInformation.StudyDescription = information.StudyDescription;
				studyInformation.StudyInstanceUid = information.StudyInstanceUid;

				return GetReceiveProgressItem(information.SourceAETitle, studyInformation, out exists);
			}

			private InternalReceiveProgressItem GetReceiveProgressItem(string fromAETitle, StudyInformation studyInformation, out bool exists)
			{
				InternalReceiveProgressItem progressItem = null;
				lock (_syncLock)
				{
					progressItem = _receiveProgressItems.Find(
						delegate(InternalReceiveProgressItem testItem)
						{
							return testItem.FromAETitle == fromAETitle &&
								testItem.StudyInformation.StudyInstanceUid == studyInformation.StudyInstanceUid;
						});

					exists = (progressItem != null);
					if (!exists)
					{
						progressItem = new InternalReceiveProgressItem();
						progressItem.Identifier = Guid.NewGuid();
						progressItem.AllowedCancellationOperations = CancellationFlags.Clear;
						progressItem.StartTime = Platform.Time;
						progressItem.LastActive = progressItem.StartTime;

						progressItem.FromAETitle = fromAETitle;
						progressItem.StudyInformation = studyInformation;

						_receiveProgressItems.Add(progressItem);
					}
				}

				return progressItem;
			}

			private void FormatErrorMessage(InternalReceiveProgressItem progressItem, Exception error)
			{
				string message = progressItem.TerminalErrorMessage != null ? progressItem.TerminalErrorMessage : error.Message;
				int errors = progressItem.TotalDataStoreCommitFailures;
				if (progressItem.TerminalErrorMessage != null)
					++errors;

				progressItem.StatusMessage = String.Format(SR.FormatReceiveErrorSummary, errors, message);
			}

			private void ProcessFileImportResults(DicomFileImporter.FileImportInformation results)
			{
				ReceivedFileImportInformation receivedFileImportInformation = results as ReceivedFileImportInformation;

				if (results.CompletedStage == DicomFileImporter.ImportStage.NotStarted)
				{
					if (results.Failed)
					{
						//Not much we can do since we can't relate it to a progress item.  Just log it.
						Platform.Log(results.Error);
					}

					return;
				}

				bool exists;
				InternalReceiveProgressItem progressItem = GetReceiveProgressItem(receivedFileImportInformation, out exists);

				lock (progressItem)
				{
					if (progressItem.StatusMessage == SR.MessagePending)
						progressItem.StatusMessage = "";

					ImportedSopInstanceInformation importedSopInformation = null;

					progressItem.LastActive = Platform.Time;

					if (receivedFileImportInformation.Failed)
					{
						//When a failure is reported, it is because the 'next' stage failed, hence the stage 
						//that was attempted did not get completed.  This is why the logic below is the way it is.
						switch (results.CompletedStage)
						{
							case DicomFileImporter.ImportStage.FileParsed:
								++progressItem.NumberOfImportFailures;
								break;
							case DicomFileImporter.ImportStage.FileMoved:
								++progressItem.NumberOfDataStoreCommitFailures;
								break;
						}

						this.FormatErrorMessage(progressItem, results.Error);
						Platform.Log(results.Error);
					}
					else if (receivedFileImportInformation.CompletedStage == DicomFileImporter.ImportStage.FileParsed)
					{
						++progressItem.NumberOfFilesParsed;
						++progressItem.NumberOfFilesReceived;
					}
					else if (receivedFileImportInformation.CompletedStage == DicomFileImporter.ImportStage.FileMoved)
					{
						if (!exists)
						{
							++progressItem.NumberOfFilesParsed;
							++progressItem.NumberOfFilesReceived;
						}

						++progressItem.NumberOfFilesImported;
					}
					else
					{
						if (!exists)
						{
							++progressItem.NumberOfFilesParsed;
							++progressItem.NumberOfFilesReceived;
							++progressItem.NumberOfFilesImported;
						}

						++progressItem.NumberOfFilesCommittedToDataStore;

						importedSopInformation = new ImportedSopInstanceInformation();
						importedSopInformation.StudyInstanceUid = receivedFileImportInformation.StudyInstanceUid;
						importedSopInformation.SeriesInstanceUid = receivedFileImportInformation.SeriesInstanceUid;
						importedSopInformation.SopInstanceUid = receivedFileImportInformation.SopInstanceUid;
						importedSopInformation.SopInstanceFileName = receivedFileImportInformation.StoredFile;
					}

					if (importedSopInformation != null)
						LocalDataStoreActivityPublisher.Instance.SopInstanceImported(importedSopInformation);

					LocalDataStoreActivityPublisher.Instance.ReceiveProgressChanged(progressItem.Clone());
				}
			}

			public void ProcessReceivedFileInformation(StoreScpReceivedFileInformation receivedFileInformation)
			{
				_parent.Importer.Enqueue(new ReceivedFileImportInformation(receivedFileInformation.FileName, receivedFileInformation.AETitle), this.ProcessFileImportResults, DicomFileImporter.DedicatedImportQueue.Import);
			}

			public void RetrieveStarted(RetrieveStudyInformation information)
			{
				lock (_syncLock)
				{
					bool exists;
					InternalReceiveProgressItem progressItem = GetReceiveProgressItem(information.FromAETitle, information.StudyInformation, out exists);
					lock (progressItem)
					{
						progressItem.StudyInformation = information.StudyInformation;
						progressItem.LastActive = Platform.Time;
						progressItem.TerminalErrorMessage = null;
						progressItem.StatusMessage = SR.MessagePending;
						LocalDataStoreActivityPublisher.Instance.ReceiveProgressChanged(progressItem.Clone());
					}	
				}
			}

			public void ReceiveError(ReceiveErrorInformation errorInformation)
			{
				lock (_syncLock)
				{
					bool exists;
					InternalReceiveProgressItem progressItem = GetReceiveProgressItem(errorInformation.FromAETitle, errorInformation.StudyInformation, out exists);
					lock (progressItem)
					{
						progressItem.StudyInformation = errorInformation.StudyInformation;
						progressItem.LastActive = Platform.Time;
						progressItem.TerminalErrorMessage = errorInformation.ErrorMessage;
						this.FormatErrorMessage(progressItem, new Exception(errorInformation.ErrorMessage));
						LocalDataStoreActivityPublisher.Instance.ReceiveProgressChanged(progressItem.Clone());
					}
				}
			}
		}
	}
}
