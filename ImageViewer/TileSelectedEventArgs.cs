#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using ClearCanvas.Common;

namespace ClearCanvas.ImageViewer
{
	/// <summary>
	/// Provides data for the <see cref="EventBroker.TileSelected"/> event.
	/// </summary>
	public class TileSelectedEventArgs : EventArgs
	{
		private ITile _selectedTile;

		internal TileSelectedEventArgs(
			ITile selectedTile)
		{
			Platform.CheckForNullReference(selectedTile, "selectedTile");
			_selectedTile = selectedTile;
		}

		/// <summary>
		/// Gets the selected <see cref="ITile"/>.
		/// </summary>
		public ITile SelectedTile
		{
			get { return _selectedTile; }
		}
	}
}
