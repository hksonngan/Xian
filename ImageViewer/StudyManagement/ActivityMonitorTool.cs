﻿#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Tools;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.ImageViewer.Common.WorkItem;

namespace ClearCanvas.ImageViewer.StudyManagement
{
	/// <summary>
	/// </summary>
	[MenuAction("show", "global-menus/MenuTools/MenuLocalServer/MenuActivityMonitor", "Show")]
	[Tooltip("show", "TooltipActivityMonitor")]
	[ExtensionOf(typeof(DesktopToolExtensionPoint))]
	public class ActivityMonitorTool : Tool<IDesktopToolContext>
	{
        public override IActionSet Actions
        {
            get
            {
                if (!WorkItemActivityMonitor.IsSupported)
                    return new ActionSet();

                return base.Actions;
            }
        }

		public void Show()
		{
            ActivityMonitorManager.Show(Context.DesktopWindow);
		}
	}
}