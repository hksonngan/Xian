﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3607
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.ImageViewer.Services.Tools {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class ServiceControlSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static ServiceControlSettings defaultInstance = ((ServiceControlSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ServiceControlSettings())));
        
        public static ServiceControlSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// Maximum time to wait for the workstation service process to start or stop.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Maximum time to wait for the workstation service process to start or stop.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public int TimeoutSeconds {
            get {
                return ((int)(this["TimeoutSeconds"]));
            }
        }
        
        /// <summary>
        /// The name of the workstation service, as it would appear in the Service Control Manager.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("The name of the workstation service, as it would appear in the Service Control Ma" +
            "nager.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ClearCanvas Workstation Shred Host Service")]
        public string ServiceName {
            get {
                return ((string)(this["ServiceName"]));
            }
        }
    }
}