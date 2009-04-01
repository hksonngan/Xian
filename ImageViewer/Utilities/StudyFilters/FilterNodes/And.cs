using System;
using System.Collections.Generic;

namespace ClearCanvas.ImageViewer.Utilities.StudyFilters.FilterNodes
{
	public sealed class And : FilterNodeBase
	{
		private readonly IList<FilterNodeBase> _operands;

		public And(params FilterNodeBase[] operands)
		{
			List<FilterNodeBase> list = new List<FilterNodeBase>();
			list.AddRange(operands);
			_operands = list.AsReadOnly();
		}

		public And(IEnumerable<FilterNodeBase> operands)
		{
			List<FilterNodeBase> list = new List<FilterNodeBase>();
			list.AddRange(operands);
			_operands = list.AsReadOnly();
		}

		public IList<FilterNodeBase> Operands
		{
			get { return _operands; }
		}

		public override bool Evaluate(StudyItem item)
		{
			if (_operands.Count == 0)
				return true;

			foreach (FilterNodeBase operand in _operands)
			{
				if (!operand.Evaluate(item))
					return false;
			}
			return true;
		}
	}
}