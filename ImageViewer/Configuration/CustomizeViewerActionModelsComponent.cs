﻿#region License

// Copyright (c) 2010, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using ClearCanvas.Common;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.Desktop.Configuration.ActionModel;
using ClearCanvas.Desktop.Trees;
using ClearCanvas.ImageViewer.BaseTools;

namespace ClearCanvas.ImageViewer.Configuration
{
	[ExtensionPoint]
	public sealed class CustomizeViewerActionModelsComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView> {}

	[AssociateView(typeof (CustomizeViewerActionModelsComponentViewExtensionPoint))]
	public class CustomizeViewerActionModelsComponent : ApplicationComponentContainer
	{
		private readonly ContainedComponentHost _tabComponentHost;
		private readonly TabComponentContainer _tabComponent;
		private readonly IImageViewer _imageViewer;
		private readonly NodePropertiesValidationPolicy _validationPolicy;
		private readonly AssignmentMap<XKeys> _keyStrokeMap;
		private readonly AssignmentMap<XMouseButtons> _initialMouseToolsMap;
		private readonly AssignmentMap<XMouseButtonCombo> _defaultMouseToolsMap;
		private readonly MultiValuedDictionary<XMouseButtons, string> _mouseButtonMap;
		private readonly MultiValuedDictionary<string, AbstractActionModelTreeLeafAction> _actionMap;
		private bool _updatingKeyStrokes = false;

		public CustomizeViewerActionModelsComponent(IImageViewer imageViewer)
		{
			_imageViewer = imageViewer;

			_keyStrokeMap = new AssignmentMap<XKeys>();
			_initialMouseToolsMap = new AssignmentMap<XMouseButtons>();
			_defaultMouseToolsMap = new AssignmentMap<XMouseButtonCombo>();
			_mouseButtonMap = new MultiValuedDictionary<XMouseButtons, string>(5);
			_actionMap = new MultiValuedDictionary<string, AbstractActionModelTreeLeafAction>();

			NodePropertiesValidationPolicy validationPolicy = new NodePropertiesValidationPolicy();
			validationPolicy.AddRule<AbstractActionModelTreeLeafAction>("CheckState", (n, value) => n.ActionId != typeof (CustomizeViewerActionModelTool).FullName + ":customize" || Equals(value, CheckState.Checked));
			validationPolicy.AddRule<AbstractActionModelTreeLeafAction>("CheckState", (n, value) => n.ActionId != "ClearCanvas.Desktop.Configuration.Tools.OptionsTool:show" || Equals(value, CheckState.Checked));
			validationPolicy.AddRule<AbstractActionModelTreeLeafAction>("ActiveMouseButtons", (n, value) => !Equals(value, XMouseButtons.None));
			validationPolicy.AddRule<AbstractActionModelTreeLeafClickAction, XKeys>("KeyStroke", this.ValidateClickActionKeyStroke);
			validationPolicy.AddRule<AbstractActionModelTreeLeafAction, bool>("InitiallyActive", this.ValidateMouseToolInitiallyActive);
			validationPolicy.AddRule<AbstractActionModelTreeLeafAction, XMouseButtonCombo>("GlobalMouseButtonCombo", this.ValidateDefaultMouseButtons);
			_validationPolicy = validationPolicy;

			_tabComponent = new TabComponentContainer();
			_tabComponent.CurrentPageChanged += OnTabComponentCurrentPageChanged;

			_tabComponent.Pages.Add(new TabPage(SR.LabelToolbar, new ImageViewerActionModelConfigurationComponent(
			                                                     	_imageViewer.GlobalActionsNamespace,
			                                                     	"global-toolbars",
			                                                     	this)));

			_tabComponent.Pages.Add(new TabPage(SR.LabelContextMenu, new ImageViewerActionModelConfigurationComponent(
			                                                         	_imageViewer.ActionsNamespace,
			                                                         	"imageviewer-contextmenu",
			                                                         	this)));

			_tabComponent.Pages.Add(new TabPage(SR.LabelMainMenu, new ImageViewerActionModelConfigurationComponent(
			                                                      	_imageViewer.GlobalActionsNamespace,
			                                                      	"global-menus",
			                                                      	this)));

			_tabComponentHost = new ContainedComponentHost(this, _tabComponent);
		}

		private bool ValidateClickActionKeyStroke(AbstractActionModelTreeLeafClickAction node, XKeys keys)
		{
			// if we're just synchronizing key strokes due to another key stroke set action, short the validation request
			if (_updatingKeyStrokes)
				return true;

			// if the key stroke is the empty value, it is always allowed
			if (keys == XKeys.None)
				return true;

			// if the key stroke contains only modifiers and no key, it is never allowed
			if ((keys & XKeys.Modifiers) != 0 && (keys & XKeys.KeyCode) == 0)
				return false;

			// if the action is not part of the viewer component then it is handled by the desktop and must be modified
			if (GetActionsById(_imageViewer.ExportedActions, node.ActionId).Count == 0 && (keys & XKeys.Modifiers) == 0)
				return false;

			// check for other assignments to the same key stroke and confirm the action if there are pre-existing assignments
			if (_keyStrokeMap.IsAssignedToOther(keys, node.ActionId))
			{
				IList<AbstractActionModelTreeLeafAction> actions = _actionMap[_keyStrokeMap[keys]];
				if (actions.Count > 0)
				{
					string message = string.Format(SR.MessageKeyStrokeAlreadyAssigned, XKeysConverter.Format(keys), actions[0].Label);
					DialogBoxAction result = base.Host.DesktopWindow.ShowMessageBox(message, MessageBoxActions.YesNo);
					if (result != DialogBoxAction.Yes)
						return false;
				}
			}

			return true;
		}

		private void UpdateClickActionKeyStroke(AbstractActionModelTreeLeafClickAction node, XKeys keys)
		{
			if (_updatingKeyStrokes)
				return;

			_updatingKeyStrokes = true;
			try
			{
				// find the old keys to which this action was assigned
				var oldKeys = _keyStrokeMap.FindAssignment(node.ActionId, XKeys.None);

				// check if updating this value actually causes a change
				if (oldKeys == keys)
					return;

				// unassign the key stroke from the old actions if it has previously been assigned to something else
				if (keys != XKeys.None && _keyStrokeMap.IsAssignedToOther(keys, node.ActionId))
				{
					foreach (AbstractActionModelTreeLeafAction action in  _actionMap[_keyStrokeMap[keys]])
					{
						if (action is AbstractActionModelTreeLeafClickAction)
							((AbstractActionModelTreeLeafClickAction) action).KeyStroke = XKeys.None;
					}
				}

				// assign the key stroke to the new actions
				foreach (AbstractActionModelTreeLeafAction action in _actionMap[node.ActionId])
				{
					if (action is AbstractActionModelTreeLeafClickAction)
						((AbstractActionModelTreeLeafClickAction) action).KeyStroke = keys;
				}

				// clear the old assignment
				if (oldKeys != XKeys.None)
					_keyStrokeMap[oldKeys] = string.Empty;

				// update the key stroke map
				if (keys != XKeys.None)
					_keyStrokeMap[keys] = node.ActionId;
			}
			finally
			{
				_updatingKeyStrokes = false;
			}
		}

		private void UpdateMouseToolMouseButton(AbstractActionModelTreeLeafAction node, XMouseButtons mouseButton)
		{
			if (_updatingKeyStrokes)
				return;

			_updatingKeyStrokes = true;
			try
			{
				// find the original mouse button to which the tool was assigned
				var oldMouseButton = _mouseButtonMap.FindKey(node.ActionId, XMouseButtons.Left);
				if (oldMouseButton == mouseButton)
					return;

				// if the tool was originally the initial tool for this button, remove it
				if (_initialMouseToolsMap.IsAssignedToMe(oldMouseButton, node.ActionId))
					_initialMouseToolsMap[oldMouseButton] = string.Empty;

				// unassign the tool from the mouse button
				_mouseButtonMap.Remove(oldMouseButton, node.ActionId);

				// update the mouse button map
				if (mouseButton != XMouseButtons.None && !_mouseButtonMap[mouseButton].Contains(node.ActionId))
					_mouseButtonMap.Add(mouseButton, node.ActionId);
			}
			finally
			{
				_updatingKeyStrokes = false;
			}
		}

		private bool ValidateMouseToolInitiallyActive(AbstractActionModelTreeLeafAction node, bool initiallyActive)
		{
			// if we're just synchronizing the value due to another update action, short the validation request
			if (_updatingKeyStrokes)
				return true;

			// find the mouse button to which this tool is assigned
			var mouseButton = _mouseButtonMap.FindKey(node.ActionId, XMouseButtons.Left);

			// check for presence of another initial tool for this button
			if (initiallyActive && _initialMouseToolsMap.IsAssignedToOther(mouseButton, node.ActionId))
			{
				IList<AbstractActionModelTreeLeafAction> actions = _actionMap[_initialMouseToolsMap[mouseButton]];
				if (actions.Count > 0)
				{
					string message = string.Format(SR.MessageMouseButtonInitialToolAlreadyAssigned, XMouseButtonsConverter.Format(mouseButton), actions[0].Label);
					DialogBoxAction result = base.Host.DesktopWindow.ShowMessageBox(message, MessageBoxActions.YesNo);
					if (result != DialogBoxAction.Yes)
						return false;
				}
			}

			return true;
		}

		private void UpdateMouseToolInitiallyActive(AbstractActionModelTreeLeafAction node, bool initiallyActive)
		{
			if (_updatingKeyStrokes)
				return;

			_updatingKeyStrokes = true;
			try
			{
				// find the mouse button to which this tool is assigned
				var mouseButton = _mouseButtonMap.FindKey(node.ActionId, XMouseButtons.Left);

				// check if updating this value actually causes a change
				var oldInitiallyActive = _initialMouseToolsMap.IsAssignedToMe(mouseButton, node.ActionId);
				if (oldInitiallyActive == initiallyActive)
					return;

				// update the initial tool map
				_initialMouseToolsMap[mouseButton] = initiallyActive ? node.ActionId : string.Empty;
			}
			finally
			{
				_updatingKeyStrokes = false;
			}
		}

		private bool ValidateDefaultMouseButtons(AbstractActionModelTreeLeafAction node, XMouseButtonCombo defaultMouseButtonCombo)
		{
			// if we're just synchronizing the value due to another update action, short the validation request
			if (_updatingKeyStrokes)
				return true;

			// check for presence of another initial tool for this button
			if (_defaultMouseToolsMap.IsAssignedToOther(defaultMouseButtonCombo, node.ActionId))
			{
				IList<AbstractActionModelTreeLeafAction> actions = _actionMap[_defaultMouseToolsMap[defaultMouseButtonCombo]];
				if (actions.Count > 0)
				{
					string message = string.Format(SR.MessageMouseButtonGlobalToolAlreadyAssigned, defaultMouseButtonCombo, actions[0].Label);
					DialogBoxAction result = base.Host.DesktopWindow.ShowMessageBox(message, MessageBoxActions.YesNo);
					if (result != DialogBoxAction.Yes)
						return false;
				}
			}

			return true;
		}

		private void UpdateDefaultMouseButtons(AbstractActionModelTreeLeafAction node, XMouseButtonCombo defaultMouseButtonCombo)
		{
			if (_updatingKeyStrokes)
				return;

			_updatingKeyStrokes = true;
			try
			{
				// find the old default mouse buttons to which this tool was assigned
				var oldMouseButtons = _defaultMouseToolsMap.FindAssignment(node.ActionId, XMouseButtonCombo.None);

				// check if updating this value actually causes a change
				if (oldMouseButtons == defaultMouseButtonCombo)
					return;

				// clear the old assignment
				if (oldMouseButtons != XMouseButtonCombo.None)
					_defaultMouseToolsMap[oldMouseButtons] = string.Empty;

				// update the default tool map
				if (defaultMouseButtonCombo != XMouseButtonCombo.None)
					_defaultMouseToolsMap[defaultMouseButtonCombo] = node.ActionId;
			}
			finally
			{
				_updatingKeyStrokes = false;
			}
		}

		// reset all node propery bindings because the values may have changed while on another page (due to key/mouse assignment mappings)
		private void OnTabComponentCurrentPageChanged(object sender, EventArgs e)
		{
			ImageViewerActionModelConfigurationComponent component = (ImageViewerActionModelConfigurationComponent) _tabComponent.CurrentPage.Component;
			component.ResetNodeProperties();
		}

		/// <summary>
		/// The host object for the contained <see cref="IApplicationComponent"/>.
		/// </summary>
		public ApplicationComponentHost TabComponentHost
		{
			get { return _tabComponentHost; }
		}

		public override void Start()
		{
			base.Start();
			_tabComponentHost.StartComponent();
		}

		public override void Stop()
		{
			_tabComponentHost.StopComponent();
			base.Stop();
		}

		public void Accept()
		{
			if (this.HasValidationErrors)
			{
				this.ShowValidation(true);
				return;
			}

			try
			{
				foreach (ActionModelConfigurationComponent component in _tabComponent.ContainedComponents)
				{
					component.Save();
				}
			}
			catch (Exception ex)
			{
				ExceptionHandler.Report(ex, this.Host.DesktopWindow);
			}

			MouseToolSettingsProfile toolProfile = MouseToolSettingsProfile.Current.Clone();
			foreach (KeyValuePair<XMouseButtons, IEnumerable<string>> pair in _mouseButtonMap)
			{
				foreach (string actionId in pair.Value)
				{
					if (toolProfile.HasEntryByActivationActionId(actionId))
					{
						var setting = toolProfile.GetEntryByActivationActionId(actionId);
						var defaultMouseButton = _defaultMouseToolsMap.FindAssignment(actionId, XMouseButtonCombo.None);
						setting.MouseButton = pair.Key;
						setting.InitiallyActive = _initialMouseToolsMap.IsAssignedToMe(pair.Key, actionId);
						setting.DefaultMouseButton = defaultMouseButton.MouseButtons;
						setting.DefaultMouseButtonModifiers = defaultMouseButton.Modifiers;
					}
				}
			}
			MouseToolSettingsProfile.Current = toolProfile;
			MouseToolSettingsProfile.SaveCurrentAsDefault();

			base.Exit(ApplicationComponentExitCode.Accepted);
		}

		public void Cancel()
		{
			base.Exit(ApplicationComponentExitCode.None);
		}

		/// <summary>
		/// Gets a value indicating whether there are any data validation errors.
		/// </summary>
		public override bool HasValidationErrors
		{
			get { return _tabComponent.HasValidationErrors || base.HasValidationErrors; }
		}

		/// <summary>
		/// Sets the <see cref="ApplicationComponent.ValidationVisible"/> property and raises the 
		/// <see cref="ApplicationComponent.ValidationVisibleChanged"/> event.
		/// </summary>
		public override void ShowValidation(bool show)
		{
			base.ShowValidation(show);
			_tabComponent.ShowValidation(show);
		}

		public override IEnumerable<IApplicationComponent> ContainedComponents
		{
			get { yield return _tabComponent; }
		}

		public override IEnumerable<IApplicationComponent> VisibleComponents
		{
			get { yield return _tabComponent; }
		}

		public override void EnsureVisible(IApplicationComponent component)
		{
			// contained component cannot be made invisible
		}

		public override void EnsureStarted(IApplicationComponent component)
		{
			// contained component is always started as long as container is started
		}

		private static IActionSet GetActionsById(IActionSet actionSet, string actionId)
		{
			return actionSet.Select(a => a.ActionID == actionId);
		}

		private class ImageViewerActionModelConfigurationComponent : ActionModelConfigurationComponent
		{
			private readonly CustomizeViewerActionModelsComponent _owner;
			private readonly MouseToolSettingsProfile _toolProfile;

			public ImageViewerActionModelConfigurationComponent(string @namespace, string site, CustomizeViewerActionModelsComponent owner)
				: base(@namespace, site, owner._imageViewer.ExportedActions, owner._imageViewer.DesktopWindow, site == "global-toolbars")
			{
				_owner = owner;

				// just keep a single copy of it for a consistent startup state - we don't store the unsaved changes in here
				_toolProfile = MouseToolSettingsProfile.Current.Clone();

				this.ValidationPolicy = _owner._validationPolicy;

				// update the keystroke and action maps
				foreach (AbstractActionModelTreeLeafAction node in base.ActionNodeMap.ActionNodes)
				{
					if (node is AbstractActionModelTreeLeafClickAction)
					{
						AbstractActionModelTreeLeafClickAction clickActionNode = (AbstractActionModelTreeLeafClickAction) node;
						if (clickActionNode.KeyStroke != XKeys.None)
						{
							if (_owner._keyStrokeMap.IsAssignedToOther(clickActionNode.KeyStroke, clickActionNode.ActionId))
								clickActionNode.KeyStroke = XKeys.None;
							else
								_owner._keyStrokeMap[clickActionNode.KeyStroke] = clickActionNode.ActionId;
						}
					}

					if (_toolProfile.HasEntryByActivationActionId(node.ActionId))
					{
						var mouseToolSetting = _toolProfile.GetEntryByActivationActionId(node.ActionId);
						var mouseButtonValue = mouseToolSetting.MouseButton.GetValueOrDefault(XMouseButtons.Left);
						if (mouseButtonValue != XMouseButtons.None)
						{
							if (mouseToolSetting.InitiallyActive.GetValueOrDefault(false))
							{
								if (!_owner._initialMouseToolsMap.IsAssignedToOther(mouseButtonValue, node.ActionId))
									_owner._initialMouseToolsMap[mouseButtonValue] = node.ActionId;
							}
							if (!_owner._mouseButtonMap[mouseButtonValue].Contains(node.ActionId))
								_owner._mouseButtonMap.Add(mouseButtonValue, node.ActionId);
						}
						var defaultMouseButtonValue = mouseToolSetting.DefaultMouseButton.GetValueOrDefault(XMouseButtons.None);
						var defaultMouseButtonModifiers = mouseToolSetting.DefaultMouseButtonModifiers.GetValueOrDefault(ModifierFlags.None);
						if (defaultMouseButtonValue != XMouseButtons.None)
						{
							var defaultMouseButton = new XMouseButtonCombo(defaultMouseButtonValue, defaultMouseButtonModifiers);
							if (!_owner._defaultMouseToolsMap.IsAssignedToOther(defaultMouseButton, node.ActionId))
								_owner._defaultMouseToolsMap[defaultMouseButton] = node.ActionId;
						}
					}
				}

				foreach (string actionId in base.ActionNodeMap.ActionIds)
					_owner._actionMap.AddRange(actionId, base.ActionNodeMap[actionId]);
			}

			public void ResetNodeProperties()
			{
				this.OnSelectedNodeChanged();
			}

			protected override void OnNodePropertiesValidated(AbstractActionModelTreeNode node, string propertyName, object value)
			{
				base.OnNodePropertiesValidated(node, propertyName, value);

				if (propertyName == "KeyStroke" && node is AbstractActionModelTreeLeafClickAction)
				{
					_owner.UpdateClickActionKeyStroke((AbstractActionModelTreeLeafClickAction) node, (XKeys) value);
				}

				if (node is AbstractActionModelTreeLeafAction)
				{
					AbstractActionModelTreeLeafAction actionNode = (AbstractActionModelTreeLeafAction) node;
					if (propertyName == "InitiallyActive")
					{
						_owner.UpdateMouseToolInitiallyActive(actionNode, (bool) value);
					}
					else if (propertyName == "ActiveMouseButtons")
					{
						_owner.UpdateMouseToolMouseButton(actionNode, (XMouseButtons) value);
					}
					else if (propertyName == "GlobalMouseButtonCombo")
					{
						_owner.UpdateDefaultMouseButtons(actionNode, (XMouseButtonCombo) value);
					}
				}
			}

			protected override IEnumerable<NodePropertiesComponent> CreateNodePropertiesComponents(AbstractActionModelTreeNode node)
			{
				List<NodePropertiesComponent> list = new List<NodePropertiesComponent>(base.CreateNodePropertiesComponents(node));
				if (node is AbstractActionModelTreeLeafClickAction)
				{
					string actionId = ((AbstractActionModelTreeLeafClickAction) node).ActionId;
					if (_toolProfile.IsRegisteredMouseToolActivationAction(actionId))
					{
						var activeMouseButtons = _owner._mouseButtonMap.FindKey(actionId, XMouseButtons.Left);
						var globalMouseButtons = _owner._defaultMouseToolsMap.FindAssignment(actionId, XMouseButtonCombo.None);
						var initiallyActive = _owner._initialMouseToolsMap.IsAssignedToMe(activeMouseButtons, actionId);
						list.Add(new MouseImageViewerToolPropertyComponent(node,
						                                                       activeMouseButtons,
						                                                       globalMouseButtons.MouseButtons,
						                                                       globalMouseButtons.Modifiers,
						                                                       initiallyActive));
					}
				}
				return list.AsReadOnly();

			}
		}

		/// <summary>
		/// Convenience class since mapping any of the assignments consist of the same operations
		/// </summary>
		/// <typeparam name="TKey"></typeparam>
		private class AssignmentMap<TKey>
		{
			private readonly Dictionary<TKey, string> _dictionary = new Dictionary<TKey, string>();

			public string this[TKey key]
			{
				get
				{
					string actionId;
					if (_dictionary.TryGetValue(key, out actionId))
						return actionId;
					return string.Empty;
				}
				set
				{
					if (!string.IsNullOrEmpty(value))
						_dictionary[key] = value;
					else
						_dictionary.Remove(key);
				}
			}

			public bool IsAssignedToMe(TKey key, string actionId)
			{
				Platform.CheckForEmptyString(actionId, "actionId");
				return _dictionary.ContainsKey(key) && _dictionary[key] == actionId;
			}

			public bool IsAssignedToOther(TKey key, string actionId)
			{
				Platform.CheckForEmptyString(actionId, "actionId");
				return _dictionary.ContainsKey(key) && _dictionary[key] != actionId;
			}

			public bool IsAssigned(TKey key)
			{
				return _dictionary.ContainsKey(key);
			}

			public TKey FindAssignment(string actionId, TKey defaultValue)
			{
				foreach (KeyValuePair<TKey, string> pair in _dictionary)
				{
					if (pair.Value == actionId)
						return pair.Key;
				}
				return defaultValue;
			}
		}
	}
}