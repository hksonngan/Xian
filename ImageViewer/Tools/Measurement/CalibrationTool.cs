#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using ClearCanvas.Common;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.ImageViewer.Graphics;
using ClearCanvas.ImageViewer.BaseTools;
using ClearCanvas.Desktop;
using ClearCanvas.ImageViewer.RoiGraphics;
using ClearCanvas.ImageViewer.RoiGraphics.Analyzers;
using ClearCanvas.ImageViewer.StudyManagement;
using System;

namespace ClearCanvas.ImageViewer.Tools.Measurement
{
	[MenuAction("calibrate", "basicgraphic-menu/MenuCalibrationTool", "Calibrate")]
	[VisibleStateObserver("calibrate", "Visible", "VisibleChanged")]
	[GroupHint("calibrate", "Tools.Image.Annotations.Measurement.Calibrate")]
	[Tooltip("calibrate", "TooltipCalibrationTool")]

	[ExtensionOf(typeof(GraphicToolExtensionPoint))]
	public class CalibrationTool : GraphicTool
	{
		public CalibrationTool()
		{
		}

		private RoiGraphic RoiGraphic
		{
			get { return Context.Graphic as RoiGraphic; }	
		}

		private IPointsGraphic LineGraphic
		{
			get
			{
				RoiGraphic graphic = RoiGraphic;
				if (graphic != null)
				{
					IPointsGraphic lineGraphic = graphic.Subject as IPointsGraphic;
					if (lineGraphic != null && lineGraphic.Points.Count == 2)
						return lineGraphic;
				}

				return null;
			}	
		}

		private Frame Frame
		{
			get
			{
				RoiGraphic graphic = RoiGraphic;
				if (graphic != null)
				{
					if (graphic.ParentPresentationImage is IImageSopProvider)
						return ((IImageSopProvider)graphic.ParentPresentationImage).Frame;
				}

				return null;
			}	
		}

		private bool IsValidGraphic()
		{
			return LineGraphic != null && Frame != null;
		}

		public override void Initialize()
		{
			base.Initialize();

			this.Visible = IsValidGraphic();
		}
		
		public void Calibrate()
		{
			if (!Visible)
				return;

			double length = GetCurrentLength();

			// Show the current length in cm, if it exists
			CalibrationComponent component = length > 0 ? new CalibrationComponent(length) : new CalibrationComponent();

			if (ApplicationComponentExitCode.Accepted != ApplicationComponent.LaunchAsDialog(
				Context.DesktopWindow, component, SR.CalibrationDialogTitle))
			{
				return;
			}

			double lengthInMm = component.LengthInCm * 10;
			ApplyCalibration(lengthInMm);
		}

		private double GetCurrentLength()
		{
			Units units = Units.Centimeters;

			IPointsGraphic line = LineGraphic;
			line.CoordinateSystem = CoordinateSystem.Source;
			try
			{
				double length = RoiLengthAnalyzer.CalculateLength(line.Points[0], line.Points[1],
									Frame.NormalizedPixelSpacing, ref units);

				if (units == Units.Centimeters)
					return length;
				else
					return 0.0;
			}
			finally
			{
				line.ResetCoordinateSystem();
			}
		}

		private void ApplyCalibration(double lengthInMm)
		{
			ApplyCalibration(lengthInMm, LineGraphic, Frame, Context.DesktopWindow);
		}

		#if	UNIT_TESTS

		internal static void TestCalibration(double lengthInMm, IPointsGraphic graphic)
		{
			Frame frame = ((IImageSopProvider)graphic.ParentPresentationImage).Frame;
			ApplyCalibration(lengthInMm, graphic, frame, null);
		}

		#endif

		private static void ApplyCalibration(double lengthInMm, IPointsGraphic line, Frame frame, IDesktopWindow desktopWindow)
		{
			double aspectRatio;
			
			if (frame.PixelAspectRatio.IsNull)
			{
				// When there is no aspect ratio tag, the image is displayed with the aspect ratio
				// of the pixel spacing, so just keep the aspect ratio the same as
				// what's displayed.  Otherwise, after calibration, a 2cm line drawn horizontally
				// would be visibly different from a 2cm line drawn vertically.
				if (!frame.NormalizedPixelSpacing.IsNull)
					aspectRatio = frame.NormalizedPixelSpacing.AspectRatio;
				else
					aspectRatio = 1;
			}
			else
			{
				aspectRatio = frame.PixelAspectRatio.Value;
			}

			line.CoordinateSystem = CoordinateSystem.Source;
			double widthInPixels = line.Points[1].X - line.Points[0].X;
			double heightInPixels = line.Points[1].Y - line.Points[0].Y;
			line.ResetCoordinateSystem();

			if (widthInPixels == 0 && heightInPixels == 0)
			{
				desktopWindow.ShowMessageBox(SR.ErrorCannotCalibrateZeroLengthRuler, MessageBoxActions.Ok);
				return;
			}

			double pixelSpacingWidth, pixelSpacingHeight;

			CalculatePixelSpacing(
				lengthInMm, 
				widthInPixels, 
				heightInPixels,
				aspectRatio,
				out pixelSpacingWidth,
				out pixelSpacingHeight);

			frame.NormalizedPixelSpacing.Calibrate(pixelSpacingHeight, pixelSpacingWidth);
			line.ParentPresentationImage.Draw();
		}

		public static void CalculatePixelSpacing(
			double lengthInMm, 
			double widthInPixels,
			double heightInPixels,
			double pixelAspectRatio,
			out double pixelSpacingWidth,
			out double pixelSpacingHeight)
		{
			double l2 = lengthInMm*lengthInMm;
			double dx2 = widthInPixels*widthInPixels;
			double dy2 = heightInPixels*heightInPixels;
			double r2 = pixelAspectRatio*pixelAspectRatio;
			pixelSpacingWidth = Math.Sqrt(l2/(dx2 + r2*dy2));
			pixelSpacingHeight = pixelAspectRatio*pixelSpacingWidth;
		}
	}
}
