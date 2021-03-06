#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.Drawing;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.ImageViewer.BaseTools;
using ClearCanvas.ImageViewer.InputManagement;
using ClearCanvas.ImageViewer.Graphics;
using ClearCanvas.ImageViewer.Mathematics;

namespace ClearCanvas.ImageViewer.Tools.Standard
{
	[ExtensionPoint]
	public sealed class MagnificationViewExtensionPoint : ExtensionPoint<IMagnificationView>
	{
	}

	public interface IMagnificationView : IView
	{
		void Open(float magnificationFactor, PresentationImage image, Point location);
		void Close();
		
		void UpdateMouseLocation(Point location);
	}

	[MenuAction("activate", "imageviewer-contextmenu/MenuMagnification", "Select", Flags = ClickActionFlags.CheckAction, InitiallyAvailable = false)]
	[MenuAction("activate", "global-menus/MenuTools/MenuStandard/MenuMagnification", "Select", Flags = ClickActionFlags.CheckAction)]
	[DropDownButtonAction("activate", "global-toolbars/ToolbarStandard/ToolbarMagnification", "Select", "MagnificationMenuModel", Flags = ClickActionFlags.CheckAction)]
	[TooltipValueObserver("activate", "Tooltip", "TooltipChanged")]
	[MouseToolButton(XMouseButtons.Left, false)]
	[MouseButtonIconSet("activate", "Icons.MagnificationToolSmall.png", "Icons.MagnificationToolMedium.png", "Icons.MagnificationToolLarge.png")]
	[CheckedStateObserver("activate", "Active", "ActivationChanged")]
	[GroupHint("activate", "Tools.Image.Magnify")]

	[MenuAction("1.5x", "magnification-dropdown/MenuMagnification1AndOneHalf", "Set1And1HalfMagnification")]
	[CheckedStateObserver("1.5x", "Magnification1And1HalfChecked", "CheckedChanged")]

	[MenuAction("2x", "magnification-dropdown/MenuMagnification2x", "Set2xMagnification")]
	[CheckedStateObserver("2x", "Magnification2xChecked", "CheckedChanged")]

	[MenuAction("4x", "magnification-dropdown/MenuMagnification4x", "Set4xMagnification")]
	[CheckedStateObserver("4x", "Magnification4xChecked", "CheckedChanged")]

	[MenuAction("6x", "magnification-dropdown/MenuMagnification6x", "Set6xMagnification")]
	[CheckedStateObserver("6x", "Magnification6xChecked", "CheckedChanged")]

	[MenuAction("8x", "magnification-dropdown/MenuMagnification8x", "Set8xMagnification")]
	[CheckedStateObserver("8x", "Magnification8xChecked", "CheckedChanged")]
	
	[ExtensionOf(typeof(ImageViewerToolExtensionPoint))]
	public class MagnificationTool : MouseImageViewerTool
	{
		private IMagnificationView _view = null;
		private readonly CursorToken _cursorToken = new CursorToken("Icons.BlankCursor.png", typeof(MagnificationTool).Assembly);

		public MagnificationTool()
			: base(SR.TooltipMagnification)
		{
			base.Behaviour |= MouseButtonHandlerBehaviour.SuppressContextMenu;
		}

		public ActionModelNode MagnificationMenuModel
		{
			get
			{
				return ActionModelRoot.CreateModel(typeof (MagnificationTool).FullName, "magnification-dropdown", base.Actions);
			}	
		}

		public bool Magnification1And1HalfChecked
		{
			get
			{
				return FloatComparer.AreEqual(ToolSettings.Default.MagnificationFactor, 1.5F);
			}	
		}

		public bool Magnification2xChecked
		{
			get
			{
				return FloatComparer.AreEqual(ToolSettings.Default.MagnificationFactor, 2.0F);
			}
		}

		public bool Magnification4xChecked
		{
			get
			{
				return FloatComparer.AreEqual(ToolSettings.Default.MagnificationFactor, 4.0F);
			}
		}

		public bool Magnification6xChecked
		{
			get
			{
				return FloatComparer.AreEqual(ToolSettings.Default.MagnificationFactor, 6.0F);
			}
		}

		public bool Magnification8xChecked
		{
			get
			{
				return FloatComparer.AreEqual(ToolSettings.Default.MagnificationFactor, 8.0F);
			}
		}
		
		public event EventHandler CheckedChanged;

		public override void Initialize()
		{
			base.Initialize();

			ToolSettings.Default.PropertyChanged += OnMagnificationSettingChanged;
			UpdateEnabled();
		}

		protected override void Dispose(bool disposing)
		{
			ToolSettings.Default.PropertyChanged -= OnMagnificationSettingChanged;

			base.Dispose(disposing);
		}

		public void Set1And1HalfMagnification()
		{
			ToolSettings.Default.MagnificationFactor = 1.5F;
			ToolSettings.Default.Save();
		}

		public void Set2xMagnification()
		{
			ToolSettings.Default.MagnificationFactor = 2F;
			ToolSettings.Default.Save();
		}

		public void Set4xMagnification()
		{
			ToolSettings.Default.MagnificationFactor = 4F;
			ToolSettings.Default.Save();
		}

		public void Set6xMagnification()
		{
			ToolSettings.Default.MagnificationFactor = 6F;
			ToolSettings.Default.Save();
		}

		public void Set8xMagnification()
		{
			ToolSettings.Default.MagnificationFactor = 8F;
			ToolSettings.Default.Save();
		}

		private void UpdateEnabled()
		{
			if (base.SelectedSpatialTransformProvider != null && base.SelectedPresentationImage is PresentationImage)
			{
				if (base.SelectedSpatialTransformProvider.SpatialTransform is ImageSpatialTransform)
				{
					Enabled = true;
					return;
				}
			}

			Enabled = false;
		}

		private void OnMagnificationSettingChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			EventsHelper.Fire(CheckedChanged, this, EventArgs.Empty);
		}

		protected override void OnPresentationImageSelected(object sender, PresentationImageSelectedEventArgs e)
		{
			UpdateEnabled();
		}

		protected override void OnTileSelected(object sender, TileSelectedEventArgs e)
		{
			UpdateEnabled();
		}

		public override bool Start(IMouseInformation mouseInformation)
		{
			if (!Enabled)
				return false;

			base.Start(mouseInformation);

			try
			{
				if (_view != null)
					throw new InvalidOperationException("A magnification component is already active.");

				MagnificationViewExtensionPoint extensionPoint = new MagnificationViewExtensionPoint();
				IMagnificationView view = (IMagnificationView)ViewFactory.CreateView(extensionPoint);

				view.Open(ToolSettings.Default.MagnificationFactor, 
					(PresentationImage)SelectedPresentationImage, mouseInformation.Location);

				_view = view;
				return true;
			}
			catch(Exception e)
			{
				ExceptionHandler.Report(e, Context.DesktopWindow);
				return false;
			}
		}

		public override bool Track(IMouseInformation mouseInformation)
		{
			if (_view != null)
			{
				_view.UpdateMouseLocation(ConstrainPointToTile(mouseInformation));
				return true;
			}

			return false;
		}

		public override bool Stop(IMouseInformation mouseInformation)
		{
			Cancel();
			return false;
		}

		public override void Cancel()
		{
			if (_view != null)
			{
				_view.Close();
				_view = null;
			}
		}

		public override CursorToken GetCursorToken(Point point)
		{
			if (_view != null)
				return _cursorToken;

			return null;
		}

		private Point ConstrainPointToTile(IMouseInformation mouseInformation)
		{
			Rectangle rectangle = mouseInformation.Tile.ClientRectangle;
			int x = mouseInformation.Location.X;
			int y = mouseInformation.Location.Y;
			if (x < rectangle.Left)
				x = rectangle.Left;
			if (x > rectangle.Right)
				x = rectangle.Right;

			if (y < rectangle.Top)
				y = rectangle.Top;
			if (y > rectangle.Bottom)
				y = rectangle.Bottom;

			return new Point(x, y);
		}
	}
}
