#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using ClearCanvas.Desktop.View.WinForms;
using NPlot;

namespace ClearCanvas.ImageViewer.Tools.ImageProcessing.RoiAnalysis.View.WinForms
{
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="PathProfileComponent"/>
    /// </summary>
    public partial class PathProfileComponentControl : ApplicationComponentUserControl
    {
        private PathProfileComponent _component;

        /// <summary>
        /// Constructor
        /// </summary>
        public PathProfileComponentControl(PathProfileComponent component)
            :base(component)
        {
            InitializeComponent();

            _component = component;

			Refresh(null, EventArgs.Empty);
			_component.AllPropertiesChanged += new EventHandler(Refresh);
		}

		void Refresh(object sender, EventArgs e)
		{
			_plotSurface.Clear();
			_plotSurface.BackColor = Color.Black;

			if (!_component.ComputeProfile())
			{
				_plotSurface.Refresh();
				return;
			}

			LinePlot linePlot = new LinePlot();
			linePlot.AbscissaData = _component.PixelIndices;
			linePlot.OrdinateData = _component.PixelValues;
			linePlot.Pen = new Pen(ClearCanvasStyle.ClearCanvasBlue);

			_plotSurface.Add(linePlot);
			_plotSurface.PlotBackColor = Color.Black;
			_plotSurface.XAxis1.Color = Color.White;
			_plotSurface.YAxis1.Color = Color.White;
			_plotSurface.Refresh();
		}
    }
}
