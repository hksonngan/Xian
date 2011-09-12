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
using System.Reflection;
using ClearCanvas.Common.Utilities;

namespace ClearCanvas.Common
{
    /// <summary>
    /// Describes a plugin, and provides properties for querying the extension points and extensions defined
    /// in the plugin.
    /// </summary>
    public class PluginInfo : IBrowsable
    {
		/// <summary>
		/// Internal method used by the framework to discover extension points and extensions declared in a plugin.
		/// </summary>
		/// <param name="asm"></param>
		/// <param name="points"></param>
		/// <param name="extensions"></param>
		internal static void DiscoverExtensionPointsAndExtensions(Assembly asm, List<ExtensionPointInfo> points, List<ExtensionInfo> extensions)
		{
			foreach (var type in asm.GetTypes())
			{
				try
				{
					var epAttr = AttributeUtils.GetAttribute<ExtensionPointAttribute>(type, false);
					if (epAttr != null)
					{
						ValidateExtensionPointClass(type);
						var extensionInterface = type.BaseType.GetGenericArguments()[0];

						points.Add(new ExtensionPointInfo(type, extensionInterface, epAttr.Name, epAttr.Description));
					}
				}
				catch (ExtensionPointException e)
				{
					// log and continue
					Platform.Log(LogLevel.Error, e.Message);
				}

				var attrs = AttributeUtils.GetAttributes<ExtensionOfAttribute>(type, false);
				foreach (var a in attrs)
				{
					extensions.Add(
						new ExtensionInfo(
							type,
							a.ExtensionPointClass,
							a.Name,
							a.Description,
							ExtensionSettings.Default.IsEnabled(type, a.Enabled)
						)
					);
				}
			}
		}

        private static void ValidateExtensionPointClass(Type extensionPointClass)
        {
            Type baseType = extensionPointClass.BaseType;
            if (!baseType.IsGenericType || !baseType.GetGenericTypeDefinition().Equals(typeof(ExtensionPoint<>)))
                throw new ExtensionPointException(string.Format(
                    SR.ExceptionExtensionPointMustSubclassExtensionPoint, extensionPointClass.FullName));
        }

        
        private readonly string _name;
        private readonly string _description;
		private readonly string _icon;
		private readonly Assembly _assembly;

        private readonly List<ExtensionPointInfo> _extensionPoints = new List<ExtensionPointInfo>();
        private readonly List<ExtensionInfo> _extensions = new List<ExtensionInfo>();

        /// <summary>
        /// Internal constructor.
        /// </summary>
        internal PluginInfo(Assembly assembly, string name, string description, string icon)
        {
            _name = name;
            _description = description;
            _assembly = assembly;
        	_icon = icon;

        	DiscoverExtensionPointsAndExtensions(assembly, _extensionPoints, _extensions);
        }

        /// <summary>
        /// Gets the set of extensions defined in this plugin, including disabled extensions.
        /// </summary>
        public IList<ExtensionInfo> Extensions
        {
            get { return _extensions.AsReadOnly(); }
        }

        /// <summary>
        /// Gets the set of extension points defined in this plugin.
        /// </summary>
        public IList<ExtensionPointInfo> ExtensionPoints
        {
            get { return _extensionPoints.AsReadOnly(); }
        }

        /// <summary>
        /// Gets the assembly that implements this plugin.
        /// </summary>
        public Assembly Assembly
        {
            get { return _assembly; }
        }

        /// <summary>
        /// The name of an icon resource to associate with the plugin.
        /// </summary>
        public string Icon
        {
            get { return _icon; }
        }

        #region IBrowsable Members

    	/// <summary>
    	/// Formal name of this object, typically the type name or assembly name.  Cannot be null.
    	/// </summary>
    	public string FormalName
        {
            get { return Assembly.FullName; }
        }

    	/// <summary>
    	/// Friendly name of the object, if one exists, otherwise null.
    	/// </summary>
    	public string Name
        {
            get { return _name; }
        }

    	/// <summary>
    	/// A friendly description of this object, if one exists, otherwise null.
    	/// </summary>
    	public string Description
        {
            get { return _description; }
        }

        #endregion
    }
}
