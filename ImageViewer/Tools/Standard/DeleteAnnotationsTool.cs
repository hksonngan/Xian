﻿#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.ImageViewer;
using ClearCanvas.ImageViewer.BaseTools;
using ClearCanvas.ImageViewer.Graphics;

namespace ClearCanvas.ImageViewer.Tools.Standard
{
	[KeyboardAction("delete", "imageviewer-keyboard/DeleteSelectedGraphic", "Delete", KeyStroke = XKeys.Delete)]
	[ExtensionOf(typeof(ImageViewerToolExtensionPoint))]
	public class DeleteSelectedAnnotationTool : ImageViewerTool
	{
		public DeleteSelectedAnnotationTool()
		{
		}

		private static bool IsGraphicInCollection(IGraphic graphic, GraphicCollection graphicCollection)
		{
			IGraphic testGraphic = graphic;
			while(testGraphic != null)
			{
				if (graphicCollection.Contains(testGraphic))
					return true;

				testGraphic = testGraphic.ParentGraphic;
			}

			return false;
		}

		public void Delete()
		{
			if (SelectedOverlayGraphicsProvider == null || SelectedPresentationImage == null)
				return;

			if (!IsGraphicInCollection(base.SelectedPresentationImage.SelectedGraphic, SelectedOverlayGraphicsProvider.OverlayGraphics))
				return;

			DrawableUndoableCommand command = new DrawableUndoableCommand(base.SelectedPresentationImage);
			command.Enqueue(new RemoveGraphicUndoableCommand(base.SelectedPresentationImage.SelectedGraphic));
			command.Execute();
			command.Name = SR.CommandDeleteAnnotation;
			base.SelectedPresentationImage.ImageViewer.CommandHistory.AddCommand(command);
		}
	}

	[MenuAction("delete", "basicgraphic-menu/MenuDeleteAnnotation", "Delete")]
	[IconSet("delete", "DeleteAnnotationToolSmall.png", "DeleteAnnotationToolMedium.png", "DeleteAnnotationToolLarge.png")]
	[GroupHint("delete", "Tools.Annotations.Delete")]

	[MenuAction("deleteall", "basicgraphic-menu/MenuDeleteAllAnnotations", "DeleteAll")]
	[IconSet("deleteall", "DeleteAllAnnotationsToolSmall.png", "DeleteAllAnnotationsToolMedium.png", "DeleteAllAnnotationsToolLarge.png")]
	[GroupHint("deleteall", "Tools.Annotations.Delete")]

	[ExtensionOf(typeof(GraphicToolExtensionPoint))]
	public class DeleteAnnotationsTool : GraphicTool
	{
		public DeleteAnnotationsTool()
		{
		}

		public void Delete()
		{
			IGraphic graphic = base.Context.Graphic;
			if (graphic == null)
				return;

			IPresentationImage image = graphic.ParentPresentationImage;
			if (image == null)
				return;

			DrawableUndoableCommand command = new DrawableUndoableCommand(graphic.ParentPresentationImage);
			command.Enqueue(new RemoveGraphicUndoableCommand(graphic));

			command.Execute();
			command.Name = SR.CommandDeleteAnnotation;
			image.ImageViewer.CommandHistory.AddCommand(command);
		}

		public void DeleteAll()
		{
			IGraphic graphic = base.Context.Graphic;
			if (graphic == null)
				return;

			IPresentationImage image = graphic.ParentPresentationImage;
			if (image == null)
				return;

			DeleteAllAnnotationsTool.DeleteAll(image);
		}
	}

	[MenuAction("deleteall", "imageviewer-contextmenu/MenuDeleteAllAnnotations", "DeleteAll")]
	[VisibleStateObserver("deleteall", "DeleteAllVisible", "DeleteAllVisibleChanged")]
	[IconSet("deleteall", "DeleteAllAnnotationsToolSmall.png", "DeleteAllAnnotationsToolMedium.png", "DeleteAllAnnotationsToolLarge.png")]
	[GroupHint("deleteall", "Tools.Image.Annotations.DeleteAll")]

	[ButtonAction("deleteallToolbar", "global-toolbars/ToolbarAnnotation/ToolbarDeleteAllAnnotations", "DeleteAll")]
	[EnabledStateObserver("deleteallToolbar", "DeleteAllVisible", "DeleteAllVisibleChanged")]
	[IconSet("deleteallToolbar", "DeleteAllAnnotationsToolSmall.png", "DeleteAllAnnotationsToolMedium.png", "DeleteAllAnnotationsToolLarge.png")]
	[Tooltip("deleteallToolbar", "TooltipDeleteAllAnnotations")]
	[GroupHint("deleteallToolbar", "Tools.Image.Annotations.DeleteAll")]

	[ExtensionOf(typeof(ImageViewerToolExtensionPoint))]
	public class DeleteAllAnnotationsTool : ImageViewerTool
	{
		private bool _deleteAllVisible;

		public DeleteAllAnnotationsTool()
		{
		}

		public event EventHandler DeleteAllVisibleChanged;

		public bool DeleteAllVisible
		{
			get { return _deleteAllVisible; }
			private set
			{
				if (_deleteAllVisible != value)
				{
					_deleteAllVisible = value;
					EventsHelper.Fire(DeleteAllVisibleChanged, this, new EventArgs());
				}
			}
		}

		public void DeleteAll()
		{
			if (DeleteAllVisible && base.SelectedPresentationImage != null)
				DeleteAll(this.SelectedPresentationImage);
		}

		public override void Initialize()
		{
			base.Initialize();
			UpdateDeleteAllVisible();

			base.ImageViewer.EventBroker.ImageDrawing += OnImageDrawing;
		}

		protected override void Dispose(bool disposing)
		{
			base.Context.Viewer.EventBroker.ImageDrawing -= OnImageDrawing;
			base.Dispose(disposing);
		}

		private void OnImageDrawing(object sender, ImageDrawingEventArgs e)
		{
			if (e.PresentationImage.Selected)
				UpdateDeleteAllVisible();
		}

		private void UpdateDeleteAllVisible()
		{
			if (base.SelectedOverlayGraphicsProvider == null)
			{
				DeleteAllVisible = false;
			}
			else
			{
				//Check that there are no visible top-level overlay graphics.
				DeleteAllVisible = CollectionUtils.Select(SelectedOverlayGraphicsProvider.OverlayGraphics, graphic => graphic.Visible).Count > 0;
			}
		}

		protected override void OnPresentationImageSelected(object sender, PresentationImageSelectedEventArgs e)
		{
			UpdateDeleteAllVisible();
			base.OnPresentationImageSelected(sender, e);
		}

		protected override void OnTileSelected(object sender, TileSelectedEventArgs e)
		{
			UpdateDeleteAllVisible();
			base.OnTileSelected(sender, e);
		}

		internal static void DeleteAll(IPresentationImage image)
		{
			IOverlayGraphicsProvider provider = image as IOverlayGraphicsProvider;
			if (provider == null)
				return;

			DrawableUndoableCommand command = new DrawableUndoableCommand(image);
			foreach (IGraphic graphic in provider.OverlayGraphics)
				command.Enqueue(new RemoveGraphicUndoableCommand(graphic));
		
			command.Execute();
			command.Name = SR.CommandDeleteAllAnnotations;
			image.ImageViewer.CommandHistory.AddCommand(command);
		}
	}
}