#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System.Configuration;
using ClearCanvas.Common.Configuration;
using ClearCanvas.Desktop;

namespace ClearCanvas.ImageViewer.Clipboard.ImageExport
{
	[SettingsGroupDescription("Stores the user's Image Export preferences.")]
	[SettingsProvider(typeof(StandardSettingsProvider))]
	internal sealed partial class ImageExportSettings
	{
		private ImageExportSettings()
		{
			ApplicationSettingsRegistry.Instance.RegisterInstance(this);
		}
	}
}
