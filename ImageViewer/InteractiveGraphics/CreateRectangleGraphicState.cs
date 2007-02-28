using System;
using System.Diagnostics;
using System.Drawing;
using ClearCanvas.Common;
using ClearCanvas.ImageViewer.InputManagement;
using ClearCanvas.ImageViewer.Graphics;

namespace ClearCanvas.ImageViewer.InteractiveGraphics
{
	public class CreateRectangleGraphicState : CreateGraphicState
	{
		private int _controlPointIndex;
		private int _numberOfPointsAnchored = 1;

		// Create a graphic object
		public CreateRectangleGraphicState(RectangleInteractiveGraphic interactiveGraphic) 
			: base(interactiveGraphic)
		{
			// This control point index corresponds to the bottom right control point
			_controlPointIndex = 3;
		}

		private InteractiveGraphic InteractiveGraphic
		{
			get { return this.StandardStatefulGraphic as InteractiveGraphic; }
		}

		public override bool Start(IMouseInformation mouseInformation)
		{
			// We just started creating
			if (_numberOfPointsAnchored == 1)
			{
				PointF mousePoint = this.InteractiveGraphic.SpatialTransform.ConvertToSource(mouseInformation.Location);
				this.InteractiveGraphic.CoordinateSystem = CoordinateSystem.Source;
				this.InteractiveGraphic.ControlPoints[0] = mousePoint;
				this.InteractiveGraphic.ControlPoints[3] = mousePoint;
				this.InteractiveGraphic.ResetCoordinateSystem();

				_numberOfPointsAnchored++;
			}
			// We're done creating
			else
			{
				if (this.SupportUndo)
				{
					base.Command = new PositionGraphicCommand(this.InteractiveGraphic, PositionGraphicCommand.CreateOperation.Create);
					base.Command.Name = SR.CommandCreateRectangleGraphic;
					this.InteractiveGraphic.ImageViewer.CommandHistory.AddCommand(base.Command);
				}

				this.StandardStatefulGraphic.State = this.StandardStatefulGraphic.CreateFocussedSelectedState();
			}

			return true;
		}

		public override bool Track(IMouseInformation mouseInformation)
		{
			PointF mousePoint = this.InteractiveGraphic.SpatialTransform.ConvertToSource(mouseInformation.Location);
			this.InteractiveGraphic.CoordinateSystem = CoordinateSystem.Source;
			this.InteractiveGraphic.ControlPoints[_controlPointIndex] = mousePoint;
			this.InteractiveGraphic.ResetCoordinateSystem();
			this.InteractiveGraphic.Draw();

			return true;
		}

		public override bool Stop(IMouseInformation mouseInformation)
		{
			return true;
		}

		public override string ToString()
		{
			return "CreateRectangleGraphicState\n";
		}
	}
}
