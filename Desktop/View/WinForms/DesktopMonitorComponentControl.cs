#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.Windows.Forms;

namespace ClearCanvas.Desktop.View.WinForms
{
    /// <summary>
    /// Provides a Windows Forms user-interface for <see cref="DesktopMonitorComponent"/>
    /// </summary>
    public partial class DesktopMonitorComponentControl : ApplicationComponentUserControl
    {
        private DesktopMonitorComponent _component;

        /// <summary>
        /// Constructor
        /// </summary>
        public DesktopMonitorComponentControl(DesktopMonitorComponent component)
            :base(component)
        {
            InitializeComponent();

            _component = component;

            _windows.Table = _component.Windows;
            _windows.DataBindings.Add("Selection", _component, "SelectedWindow", true, DataSourceUpdateMode.OnPropertyChanged);

            _workspaces.Table = _component.Workspaces;
            _workspaces.DataBindings.Add("Selection", _component, "SelectedWorkspace", true, DataSourceUpdateMode.OnPropertyChanged);
            _shelves.Table = _component.Shelves;
            _shelves.DataBindings.Add("Selection", _component, "SelectedShelf", true, DataSourceUpdateMode.OnPropertyChanged);

            _events.Table = _component.EventLog;
        }

        private void _openWindow_Click(object sender, EventArgs e)
        {
            _component.OpenWindow();
        }

        private void _activateWindow_Click(object sender, EventArgs e)
        {
            _component.ActivateSelectedWindow();
        }

        private void _closeWindow_Click(object sender, EventArgs e)
        {
            _component.CloseSelectedWindow();
        }

        private void _openWorkspace_Click(object sender, EventArgs e)
        {
            _component.OpenWorkspace();
        }

        private void _activateWorkspace_Click(object sender, EventArgs e)
        {
            _component.ActivateSelectedWorkspace();
        }

        private void _closeWorkspace_Click(object sender, EventArgs e)
        {
            _component.CloseSelectedWorkspace();
        }

        private void _openShelf_Click(object sender, EventArgs e)
        {
            _component.OpenShelf();
        }

        private void _activateShelf_Click(object sender, EventArgs e)
        {
            _component.ActivateSelectedShelf();
        }

        private void _showShelf_Click(object sender, EventArgs e)
        {
            _component.ShowSelectedShelf();
        }

        private void _hideShelf_Click(object sender, EventArgs e)
        {
            _component.HideSelectedShelf();
        }

        private void _closeShelf_Click(object sender, EventArgs e)
        {
            _component.CloseSelectedShelf();
        }
    }
}
