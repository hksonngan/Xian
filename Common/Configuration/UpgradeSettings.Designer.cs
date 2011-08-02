﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.Common.Configuration {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class UpgradeSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static UpgradeSettings defaultInstance = ((UpgradeSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new UpgradeSettings())));
        
        public static UpgradeSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// User upgrade steps (such as settings) that have already been completed; checked each time the application starts up.
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("User upgrade steps (such as settings) that have already been completed; checked e" +
            "ach time the application starts up.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<completed-user-upgrade-steps />")]
        public global::System.Xml.XmlDocument CompletedUserUpgradeStepsXml {
            get {
                return ((global::System.Xml.XmlDocument)(this["CompletedUserUpgradeStepsXml"]));
            }
            set {
                this["CompletedUserUpgradeStepsXml"] = value;
            }
        }
        
        /// <summary>
        /// Specifies whether or not the application should run the user upgrade on startup.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Specifies whether or not the application should run the user upgrade on startup.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool UserUpgradeEnabled {
            get {
                return ((bool)(this["UserUpgradeEnabled"]));
            }
        }
    }
}
