#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.Reflection;
using ClearCanvas.Common.Utilities;

namespace ClearCanvas.Desktop.Actions
{
    /// <summary>
    /// Abstract base class for action attributes that declare state observers.
    /// </summary>
    public abstract class StateObserverAttribute : ActionDecoratorAttribute
    {
        private readonly string _observedProperty;
        private readonly string _observedChangeEvent;

        /// <summary>
        /// Constructor.
        /// </summary>
		/// <param name="actionID">The unique identifer of the action.</param>
        /// <param name="observedProperty">The name of the property to bind to.</param>
        /// <param name="observedChangeEvent">The name of the event to bind to that notifies subscribers of changes in the property value.</param>
        protected StateObserverAttribute(string actionID, string observedProperty, string observedChangeEvent)
            : base(actionID)
        {
            _observedProperty = observedProperty;
            _observedChangeEvent = observedChangeEvent;
        }

        /// <summary>
        /// The name of the property to bind to.
        /// </summary>
        public string PropertyName { get { return _observedProperty; } }

        /// <summary>
        /// The name of the property change notification event to bind to.
        /// </summary>
        public string ChangeEventName { get { return _observedChangeEvent; } }

		/// <summary>
		/// Binds an <see cref="IAction"/> instance to the <paramref name="actionProperty"/> and 
		/// <paramref name="actionEvent"/> on the target object, via the specified <see cref="IActionBuildingContext"/>.
		/// </summary>
        protected void Bind<T>(IActionBuildingContext builder, string actionProperty, string actionEvent)
        {
            ValidateProperty(builder.ActionTarget, this.PropertyName, typeof(T));
            ValidateEvent(builder.ActionTarget, this.ChangeEventName);

            IObservablePropertyBinding<T> toolBinding = new DynamicObservablePropertyBinding<T>(builder.ActionTarget, this.PropertyName, this.ChangeEventName);
            IObservablePropertyBinding<T> actionBinding = new DynamicObservablePropertyBinding<T>(builder.Action, actionProperty, actionEvent);

            ObservablePropertyCoupler<T>.Couple(toolBinding, actionBinding);
        }

		/// <summary>
		/// Validates the event that is to be bound to exists in the target object.
		/// </summary>
		protected void ValidateEvent(object target, string eventName)
        {
            EventInfo info = target.GetType().GetEvent(eventName);
            if (info == null)
            {
                throw new ActionBuilderException(
                    string.Format(SR.ExceptionActionBuilderEventDoesNotExist, eventName, target.GetType().FullName));
            }
        }

		/// <summary>
		/// Validates the property that is to be bound to exists in the target object.
		/// </summary>
		protected void ValidateProperty(object target, string propertyName, Type type)
        {
            PropertyInfo info = target.GetType().GetProperty(propertyName, type);
            if (info == null)
            {
                throw new ActionBuilderException(
                    string.Format(SR.ExceptionActionBuilderPropertyDoesNotExist, propertyName, target.GetType().FullName));
            }

            MethodInfo getter = info.GetGetMethod();
            if (getter == null)
            {
                throw new ActionBuilderException(
                    string.Format(SR.ExceptionActionBuilderPropertyDoesNotHavePublicGetMethod, propertyName, target.GetType().FullName));
            }
        }
    }
}
