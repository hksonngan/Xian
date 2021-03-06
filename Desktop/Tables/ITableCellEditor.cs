#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;

namespace ClearCanvas.Desktop.Tables
{
	/// <summary>
	/// Defines an interface to a table cell editor.
	/// </summary>
	public interface ITableCellEditor
	{
		/// <summary>
		/// Called by the framework to associate this editor with the specified column.
		/// </summary>
		/// <param name="column"></param>
		void SetColumn(ITableColumn column);

		/// <summary>
		/// Informs the editor that it is going to begin an edit on the specified item.
		/// </summary>
		/// <param name="item"></param>
		void BeginEdit(object item);

		/// <summary>
		/// Gets or sets the value (e.g. content) of the editor.
		/// </summary>
		object Value { get; set; }

		/// <summary>
		/// Occurs when the <see cref="Value"/> property is modified.
		/// </summary>
		event EventHandler ValueChanged;
	}
}
