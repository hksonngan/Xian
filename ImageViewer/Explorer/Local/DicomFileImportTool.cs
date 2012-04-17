#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.Collections.Generic;
using System.ServiceModel;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Tools;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.ImageViewer.Common.WorkItem;
using ClearCanvas.ImageViewer.Services;

namespace ClearCanvas.ImageViewer.Explorer.Local
{
	[MenuAction("Import", "explorerlocal-contextmenu/ImportDicomFiles", "Import")]
    [ActionFormerly("Import", "ClearCanvas.ImageViewer.Services.Tools.DicomFileImportTool:Import")]
    [Tooltip("Import", "TooltipImportDicomFiles")]
	[IconSet("Import", "Icons.DicomFileImportToolSmall.png", "Icons.DicomFileImportToolMedium.png", "Icons.DicomFileImportToolLarge.png")]
	[EnabledStateObserver("Import", "Enabled", "EnabledChanged")]
	[ViewerActionPermission("Import", Common.AuthorityTokens.Study.Import)]

	[ExtensionOf(typeof(LocalImageExplorerToolExtensionPoint))]
	public class DicomFileImportTool : Tool<ILocalImageExplorerToolContext>
	{
		public event EventHandler EnabledChanged;
		private bool _enabled = true;

		public bool Enabled
		{
			get { return _enabled; }
			private set
			{
				if (_enabled != value)
				{
					_enabled = value;
					EventsHelper.Fire(EnabledChanged, this, EventArgs.Empty);
				}
			}
		}

		public override void Initialize()
		{
			base.Initialize();
			Context.SelectedPathsChanged += OnContextSelectedPathsChanged;
		}

		protected override void Dispose(bool disposing)
		{
			Context.SelectedPathsChanged -= OnContextSelectedPathsChanged;
			base.Dispose(disposing);
		}

		private void OnContextSelectedPathsChanged(object sender, EventArgs e)
		{
			Enabled = Context.SelectedPaths.Count > 0;
		}

		public void Import()
		{
			var filePaths = new List<string>();

			foreach (string path in this.Context.SelectedPaths)
			{
				if (string.IsNullOrEmpty(path))
					continue;

				filePaths.Add(path);
			}

			if (filePaths.Count == 0)
				return;
	
			try
			{
                var importClient = new DicomFileImportClient();
                importClient.ImportFileList(filePaths, BadFileBehaviourEnum.Ignore, FileImportBehaviourEnum.Copy);
			}
			catch (EndpointNotFoundException)
			{
			    var message = String.Format(SR.FormatMessageImportWorkItemServiceNotRunning, LocalServiceProcess.Name);
                Context.DesktopWindow.ShowMessageBox(message, MessageBoxActions.Ok);
			}
			catch (Exception e)
			{
				ExceptionHandler.Report(e, SR.MessageFailedToImportSelection, this.Context.DesktopWindow);
			}
		}
	}
}