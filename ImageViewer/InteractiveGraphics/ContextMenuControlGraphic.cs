#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using ClearCanvas.Common.Utilities;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.ImageViewer.Graphics;
using ClearCanvas.ImageViewer.InputManagement;

namespace ClearCanvas.ImageViewer.InteractiveGraphics
{
	/// <summary>
	/// An interactive graphic that adds a context menu to a subject graphic.
	/// </summary>
	[Cloneable]
	public class ContextMenuControlGraphic : ControlGraphic, IContextMenuProvider
	{
		[CloneCopyReference]
		private IActionSet _actions;

		private string _namespace;
		private string _site;

		/// <summary>
		/// Constructs an instance of a <see cref="ContextMenuControlGraphic"/> with no initial context menu actions.
		/// </summary>
		/// <param name="subject">The subject graphic.</param>
		public ContextMenuControlGraphic(IGraphic subject)
			: this(string.Empty, string.Empty, null, subject) {}

		/// <summary>
		/// Constructs an instance of a <see cref="ContextMenuControlGraphic"/> with the specified initial context menu actions.
		/// </summary>
		/// <param name="site">The action model site for the context menu (see <see cref="ActionPath.Site"/>).</param>
		/// <param name="actions">The set of actions on the context menu.</param>
		/// <param name="subject">The subject graphic.</param>
		public ContextMenuControlGraphic(string site, IActionSet actions, IGraphic subject)
			: this(string.Empty, site, actions, subject) {}

		/// <summary>
		/// Constructs an instance of a <see cref="ContextMenuControlGraphic"/> with the specified initial context menu actions.
		/// </summary>
		/// <param name="namespace">The namespace to qualify the <paramref name="site"/>.</param>
		/// <param name="site">The action model site for the context menu (see <see cref="ActionPath.Site"/>).</param>
		/// <param name="actions">The set of actions on the context menu.</param>
		/// <param name="subject">The subject graphic.</param>
		public ContextMenuControlGraphic(string @namespace, string site, IActionSet actions, IGraphic subject)
			: base(subject)
		{
			_namespace = @namespace;
			_site = site;
			_actions = actions;
		}

		/// <summary>
		/// Cloning constructor.
		/// </summary>
		/// <param name="source">The source object from which to clone.</param>
		/// <param name="context">The cloning context object.</param>
		protected ContextMenuControlGraphic(ContextMenuControlGraphic source, ICloningContext context)
			: base(source, context)
		{
			context.CloneFields(source, this);
		}

		/// <summary>
		/// Gets or sets the actions to include on the context menu.
		/// </summary>
		public virtual IActionSet Actions
		{
			get { return _actions; }
			set { _actions = value; }
		}

		/// <summary>
		/// Gets the namespace with which to qualify the action model <see cref="Site"/>.
		/// </summary>
		public string Namespace
		{
			get
			{
				if (string.IsNullOrEmpty(_namespace))
					return typeof (ContextMenuControlGraphic).FullName;
				return _namespace;
			}
			protected set { _namespace = value; }
		}

		/// <summary>
		/// Gets the action model site.
		/// </summary>
		/// <seealso cref="ActionPath.Site"/>
		public string Site
		{
			get { return _site; }
			protected set { _site = value; }
		}

		/// <summary>
		/// Called by <see cref="ControlGraphic"/> in response to a mouse button click via <see cref="ControlGraphic.Start"/>.
		/// </summary>
		/// <param name="mouseInformation">The mouse input information.</param>
		/// <returns>True if the <see cref="ControlGraphic"/> did something as a result of the call and hence would like to receive capture; False otherwise.</returns>
		protected override bool Start(IMouseInformation mouseInformation)
		{
			if (mouseInformation.ActiveButton == XMouseButtons.Right)
			{
				this.CoordinateSystem = CoordinateSystem.Destination;
				try
				{
					if (this.HitTest(mouseInformation.Location))
					{
						return true;
					}
				}
				finally
				{
					this.ResetCoordinateSystem();
				}
			}
			return base.Start(mouseInformation);
		}

		/// <summary>
		/// Gets a set of exported <see cref="IAction"/>s.
		/// </summary>
		/// <remarks>
		/// <para>
		/// This mechanism is useful when a particular component defines generally useful <see cref="IAction"/>s
		/// without requiring specific knowledge of the action model sites that the client code uses.
		/// </para>
		/// <para>
		/// Overriding implementations should generally call the base implementation and invoke a <see cref="IActionSet.Union"/>
		/// with any new actions the derived class wishes to provide in order to maintain full functionality of any
		/// control graphics further down in the chain.
		/// </para>
		/// </remarks>
		/// <param name="site">The action model site at which the actions should reside.</param>
		/// <param name="mouseInformation">The mouse input when the action model was requested, such as in response to a context menu request.</param>
		/// <returns>A set of exported <see cref="IAction"/>s.</returns>
		public sealed override IActionSet GetExportedActions(string site, IMouseInformation mouseInformation)
		{
			return base.GetExportedActions(site, mouseInformation).Union(this.Actions);
		}

		#region IContextMenuProvider Members

		/// <summary>
		/// Gets the context menu <see cref="ActionModelNode"/> based on the current state of the mouse.
		/// </summary>
		public ActionModelNode GetContextMenuModel(IMouseInformation mouseInformation)
		{
			if (string.IsNullOrEmpty(this.Site))
				return null;

			return ActionModelRoot.CreateModel(this.Namespace, this.Site, ((IExportedActionsProvider) this).GetExportedActions(this.Site, mouseInformation));
		}

		#endregion
	}
}