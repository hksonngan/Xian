﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.1433
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.ImageServer.Services.WorkQueue {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "8.0.0.0")]
    internal sealed partial class WorkQueueSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static WorkQueueSettings defaultInstance = ((WorkQueueSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new WorkQueueSettings())));
        
        public static WorkQueueSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// Delay between queries for new entries in the WorkQueue in milliseconds
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Delay between queries for new entries in the WorkQueue in milliseconds")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10000")]
        public int WorkQueueQueryDelay {
            get {
                return ((int)(this["WorkQueueQueryDelay"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int WorkQueueMaxFailureCount {
            get {
                return ((int)(this["WorkQueueMaxFailureCount"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public int WorkQueueFailureDelayMinutes {
            get {
                return ((int)(this["WorkQueueFailureDelayMinutes"]));
            }
        }
        
        /// <summary>
        /// The number of seconds delay between attempting to process a queue entry.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("The number of seconds delay between attempting to process a queue entry.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("30")]
        public int WorkQueueProcessDelayMedPrioritySeconds {
            get {
                return ((int)(this["WorkQueueProcessDelayMedPrioritySeconds"]));
            }
        }
        
        /// <summary>
        /// The number of seconds to delay after processing until the queue entry is deleted.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("The number of seconds to delay after processing until the queue entry is deleted." +
            "")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("90")]
        public int WorkQueueExpireDelaySeconds {
            get {
                return ((int)(this["WorkQueueExpireDelaySeconds"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("60")]
        public int WorkQueueProcessDelayLowPrioritySeconds {
            get {
                return ((int)(this["WorkQueueProcessDelayLowPrioritySeconds"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("15")]
        public int WorkQueueProcessDelayHighPrioritySeconds {
            get {
                return ((int)(this["WorkQueueProcessDelayHighPrioritySeconds"]));
            }
        }
    }
}
