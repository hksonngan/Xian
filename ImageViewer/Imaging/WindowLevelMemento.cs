using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Common;
using ClearCanvas.Common.Application;

namespace ClearCanvas.Workstation.Model.Imaging
{
	public class WindowLevelMemento : IMemento
	{
		private double m_WindowWidth = 1.0f;
		private double m_WindowCenter = 0.0f;

		public WindowLevelMemento()
		{

		}

		public double WindowWidth
		{
			get { return m_WindowWidth; }
			set { m_WindowWidth = value; }
		}

		public double WindowCenter
		{
			get { return m_WindowCenter; }
			set { m_WindowCenter = value; }
		}

		public override bool Equals(object obj)
		{
			Platform.CheckForNullReference(obj, "obj");
			WindowLevelMemento memento = obj as WindowLevelMemento;
			Platform.CheckForInvalidCast(memento, "obj", "WindowLevelMemento");

			return (this.WindowCenter == memento.WindowCenter &&
					this.WindowWidth == memento.WindowWidth);
		}

		public override int GetHashCode()
		{
			// Normally, you would calculate a hash code dependent on immutable
			// member fields since we've given this object value type semantics
			// because of how we've overridden Equals().  However, this is a memento
			// and thus the actualy contents of the memento are irrelevant if they 
			// were ever put in a hashtable.  We are in fact interested in the instance.
			return base.GetHashCode();
		}
	}
}
