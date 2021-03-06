#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.IO;
using System.Xml;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Dicom;
using ClearCanvas.Dicom.Utilities.Command;
using ClearCanvas.Dicom.Utilities.Xml;
using ClearCanvas.ImageServer.Common.Command;
using ClearCanvas.ImageServer.Model;
using ClearCanvas.ImageServer.Rules;

namespace ClearCanvas.ImageServer.Services.Archiving.Hsm
{
	/// <summary>
	/// <see cref="CommandBase"/> for applying rules to a study after it has been restored.
	/// </summary>
	public class ApplyRulesCommand : CommandBase
	{
		private readonly string _directory;
		private readonly string _studyInstanceUid;
		private readonly ServerActionContext _context;
		private readonly ServerRulesEngine _engine;
		public ApplyRulesCommand(string directory, string studyInstanceUid, ServerActionContext context) : base("Apply Server Rules", true)
		{
			_directory = directory;
			_studyInstanceUid = studyInstanceUid;
			_context = context;
			_engine = new ServerRulesEngine(ServerRuleApplyTimeEnum.StudyRestored, _context.ServerPartitionKey);
			_engine.Load();
		}

		/// <summary>
		/// Apply the rules.
		/// </summary>
		/// <remarks>
		/// When rules are applied, we are simply adding new <see cref="ServerDatabaseCommand"/> instances
		/// for the rules to the currently executing <see cref="ServerCommandProcessor"/>.  They will be
		/// executed after all other rules have been executed.
		/// </remarks>
		protected override void OnExecute(CommandProcessor theProcessor)
		{
			string studyXmlFile = Path.Combine(_directory, String.Format("{0}.xml", _studyInstanceUid));
			StudyXml theXml = new StudyXml(_studyInstanceUid);

			if (File.Exists(studyXmlFile))
			{
				using (Stream fileStream = FileStreamOpener.OpenForRead(studyXmlFile, FileMode.Open))
				{
					XmlDocument theDoc = new XmlDocument();

					StudyXmlIo.Read(theDoc, fileStream);

					theXml.SetMemento(theDoc);

					fileStream.Close();
				}
			}
			else
			{
				string errorMsg = String.Format("Unable to load study XML file of restored study: {0}", studyXmlFile);

				Platform.Log(LogLevel.Error, errorMsg);
				throw new ApplicationException(errorMsg);
			}

			DicomFile defaultFile = null;
			bool rulesExecuted = false;
			foreach (SeriesXml seriesXml in theXml)
			{
				foreach (InstanceXml instanceXml in seriesXml)
				{
					// Skip non-image objects
					if (instanceXml.SopClass.Equals(SopClass.KeyObjectSelectionDocumentStorage)
					    || instanceXml.SopClass.Equals(SopClass.GrayscaleSoftcopyPresentationStateStorageSopClass)
					    || instanceXml.SopClass.Equals(SopClass.BlendingSoftcopyPresentationStateStorageSopClass)
					    || instanceXml.SopClass.Equals(SopClass.ColorSoftcopyPresentationStateStorageSopClass))
					{
						// Save the first one encountered, just in case the whole study is non-image objects.
						if (defaultFile == null)
							defaultFile = new DicomFile("test", new DicomAttributeCollection(), instanceXml.Collection);
						continue;
					}

					DicomFile file = new DicomFile("test", new DicomAttributeCollection(), instanceXml.Collection);
					_context.Message = file;
					_engine.Execute(_context);
					rulesExecuted = true;
					break;
				}
				if (rulesExecuted) break;
			}

			if (!rulesExecuted && defaultFile != null)
			{
				_context.Message = defaultFile;
				_engine.Execute(_context);
			}
		}

		/// <summary>
		/// Nothing to undo.  We just inserted into the command processing new DB updates, which will
		/// be rolledback on their own.
		/// </summary>
		protected override void OnUndo()
		{
			
		}
	}
}
