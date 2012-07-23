﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.269
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.Ris.Client {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class CannedTextSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static CannedTextSettings defaultInstance = ((CannedTextSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new CannedTextSettings())));
        
        public static CannedTextSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// Enable validation of characters in the canned text name.  If true, the name can only contain spaces and alphabetic characters, which ensures the name can be recognized by speech recognition.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Enable validation of characters in the canned text name.  If true, the name can o" +
            "nly contain spaces and alphabetic characters, which ensures the name can be reco" +
            "gnized by speech recognition.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool RestrictNameToAlphaChars {
            get {
                return ((bool)(this["RestrictNameToAlphaChars"]));
            }
        }
        
        /// <summary>
        /// Remembers the name of the last sorted column in the CannedTextSummaryComponent
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Remembers the name of the last sorted column in the CannedTextSummaryComponent")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Name")]
        public string SummarySortColumnName {
            get {
                return ((string)(this["SummarySortColumnName"]));
            }
            set {
                this["SummarySortColumnName"] = value;
            }
        }
        
        /// <summary>
        /// Remembers the last sort direction of the sorted column in the CannedTextSummaryComponent
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Remembers the last sort direction of the sorted column in the CannedTextSummaryCo" +
            "mponent")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool SummarySortAscending {
            get {
                return ((bool)(this["SummarySortAscending"]));
            }
            set {
                this["SummarySortAscending"] = value;
            }
        }
        
        /// <summary>
        /// Enable validation of characters in defined fields.  If true, contents enclosed within square brackets can only contain spaces and alphabetic characters, which ensures the name can be recognized by speech recognition.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Enable validation of characters in defined fields.  If true, contents enclosed wi" +
            "thin square brackets can only contain spaces and alphabetic characters, which en" +
            "sures the name can be recognized by speech recognition.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool RestrictFieldsToAlphaChars {
            get {
                return ((bool)(this["RestrictFieldsToAlphaChars"]));
            }
        }
    }
}
