using System;
using System.Drawing;
using System.Diagnostics;
using ClearCanvas.Common;
using ClearCanvas.Common.Mathematics;
using ClearCanvas.Workstation.Model;
using ClearCanvas.Workstation.Model.Layers;
using ClearCanvas.Common.Application;

namespace ClearCanvas.Workstation.Model.DynamicOverlays
{
	/// <summary>
	/// Summary description for CalloutGraphic.
	/// </summary>
	public class CalloutGraphic : StatefulGraphic, IMemorable
	{
        private InvariantTextPrimitive _textGraphic;
		private LinePrimitive _lineGraphic;

        public CalloutGraphic()
        {
			BuildGraphic();
			base.State = CreateInactiveState();
        }

		public string Text
		{
			get { return _textGraphic.Text; }
			set { _textGraphic.Text = value; }
		}

		public PointF Location
		{
			get { return _textGraphic.AnchorPoint; }
			set 
			{ 
				_textGraphic.AnchorPoint = value;
			}
		}

		public PointF Start
		{
			get
			{
				return _lineGraphic.Pt1;
			}
		}

		public PointF End
		{
			get { return _lineGraphic.Pt2; }
			set 
			{
				_lineGraphic.Pt2 = value;
				SetCalloutLineStart();
			}
		}

		public event EventHandler<PointChangedEventArgs> LocationChanged
		{
			add { _textGraphic.AnchorPointChanged += value; }
			remove { _textGraphic.AnchorPointChanged += value; }
		}

		public IMemento CreateMemento()
        {
			PointMemento memento = new PointMemento();

			// Must store source coordinates in memento
			this.CoordinateSystem = CoordinateSystem.Source;
			memento.Point = this.Location;
			this.ResetCoordinateSystem();

			return memento;
        }

        public void SetMemento(IMemento memento)
        {
			PointMemento pointMemento = memento as PointMemento;
			Platform.CheckForInvalidCast(pointMemento, "memento", "PointMemento");

			this.CoordinateSystem = CoordinateSystem.Source;
			this.Location = pointMemento.Point;
			this.ResetCoordinateSystem();

			SetCalloutLineStart();
		}

		public override void Move(SizeF delta)
		{
			_textGraphic.Move(delta);
		}
 
		public override bool HitTest(XMouseEventArgs e)
        {
            return _textGraphic.HitTest(e) || _lineGraphic.HitTest(e);
        }

		private void BuildGraphic()
		{
			_textGraphic = new InvariantTextPrimitive();
			base.Graphics.Add(_textGraphic);
			_textGraphic.AutoHandleMouse = false;
			_textGraphic.BoundingBoxChanged += new EventHandler<RectangleChangedEventArgs>(OnTextBoundingBoxChanged);

			_lineGraphic = new LinePrimitive();
			base.Graphics.Add(_lineGraphic);
			_lineGraphic.AutoHandleMouse = false;
			_lineGraphic.LineStyle = LineStyle.Dash;
		}

		private void SetCalloutLineStart()
		{
			_lineGraphic.CoordinateSystem = CoordinateSystem.Destination;
			_lineGraphic.Pt1 = CalculateCalloutLineStartPoint();
			_lineGraphic.ResetCoordinateSystem();
		}

		private PointF CalculateCalloutLineStartPoint()
		{
			_textGraphic.CoordinateSystem = CoordinateSystem.Destination;
			_lineGraphic.CoordinateSystem = CoordinateSystem.Destination;

			RectangleF boundingBox = _textGraphic.BoundingBox;
			boundingBox.Inflate(3, 3);

			Point topLeft = new Point(
				(int)boundingBox.Left,
				(int)boundingBox.Top);
			Point topRight = new Point(
				(int)boundingBox.Right,
				(int)boundingBox.Top);
			Point bottomLeft = new Point(
				(int)boundingBox.Left,
				(int)boundingBox.Bottom);
			Point bottomRight = new Point(
				(int)boundingBox.Right,
				(int)boundingBox.Bottom);

			Point center = Vector.Midpoint(topLeft, bottomRight);

			Point intersectionPoint;
			Point attachmentPoint = new Point((int) this.End.X, (int) this.End.Y);

			_textGraphic.ResetCoordinateSystem();
			_lineGraphic.ResetCoordinateSystem();

			if (Vector.LineSegmentIntersection(
				center,
				attachmentPoint,
				topLeft,
				topRight,
				out intersectionPoint) == Vector.LineSegments.Intersect)
			{
				return intersectionPoint;
			}

			if (Vector.LineSegmentIntersection(
				center,
				attachmentPoint,
				bottomLeft,
				bottomRight,
				out intersectionPoint) == Vector.LineSegments.Intersect)
			{
				return intersectionPoint;
			}

			if (Vector.LineSegmentIntersection(
				center,
				attachmentPoint,
				topLeft,
				bottomLeft,
				out intersectionPoint) == Vector.LineSegments.Intersect)
			{
				return intersectionPoint;
			}

			if (Vector.LineSegmentIntersection(
				center,
				attachmentPoint,
				topRight,
				bottomRight,
				out intersectionPoint) == Vector.LineSegments.Intersect)
			{
				return intersectionPoint;
			}

			return attachmentPoint;
		}

		private void OnTextBoundingBoxChanged(object sender, RectangleChangedEventArgs e)
		{
			SetCalloutLineStart();
		}
    }
}
