#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

namespace ClearCanvas.Desktop.Actions
{
    /// <summary>
    /// Declares a tooltip message to associate with an action.
    /// </summary>
    public class TooltipAttribute : ActionDecoratorAttribute
    {
        private readonly string _tooltip;

        /// <summary>
        /// Attribute constructor.
        /// </summary>
        /// <param name="actionID">The logical action identifier to which this attribute applies.</param>
        /// <param name="tooltip">The tooltip message to associate with the action.</param>
        public TooltipAttribute(string actionID, string tooltip)
            :base(actionID)
        {
            _tooltip = tooltip;
        }

        /// <summary>
        /// The tooltip message.
        /// </summary>
        public string TooltipText { get { return _tooltip; } }

		/// <summary>
		/// Sets the <see cref="IAction.Tooltip"/> value for and <see cref="IAction"/> instance,
		/// via the specified <see cref="IActionBuildingContext"/>.
		/// </summary>
        public override void Apply(IActionBuildingContext builder)
        {
            // assert _action != null
            builder.Action.Tooltip = builder.ResourceResolver.LocalizeString(this.TooltipText);
        }
    }
}
