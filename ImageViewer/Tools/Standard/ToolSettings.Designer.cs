﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.ImageViewer.Tools.Standard {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class ToolSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static ToolSettings defaultInstance = ((ToolSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ToolSettings())));
        
        public static ToolSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// Enables display of post-modality LUT value on non CT images.
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Enables display of post-modality LUT value on non CT images.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ShowNonCTModPixelValue {
            get {
                return ((bool)(this["ShowNonCTModPixelValue"]));
            }
            set {
                this["ShowNonCTModPixelValue"] = value;
            }
        }
        
        /// <summary>
        /// Enables display of pre-modality LUT value on CT images.
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Enables display of pre-modality LUT value on CT images.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ShowCTRawPixelValue {
            get {
                return ((bool)(this["ShowCTRawPixelValue"]));
            }
            set {
                this["ShowCTRawPixelValue"] = value;
            }
        }
        
        /// <summary>
        /// Enables display of post-VOI LUT value.
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Enables display of post-VOI LUT value.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ShowVOIPixelValue {
            get {
                return ((bool)(this["ShowVOIPixelValue"]));
            }
            set {
                this["ShowVOIPixelValue"] = value;
            }
        }
        
        /// <summary>
        /// Last used text tool mode.
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Last used text tool mode.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("TextCallout")]
        public string TextCalloutMode {
            get {
                return ((string)(this["TextCalloutMode"]));
            }
            set {
                this["TextCalloutMode"] = value;
            }
        }
        
        /// <summary>
        /// Magnification factor for magnifier tool.
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Magnification factor for magnifier tool.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public float MagnificationFactor {
            get {
                return ((float)(this["MagnificationFactor"]));
            }
            set {
                this["MagnificationFactor"] = value;
            }
        }
        
        /// <summary>
        /// Inverts the operation of the Zoom tool such that moving the mouse up zooms out, and moving down zooms in.
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Inverts the operation of the Zoom tool such that moving the mouse up zooms out, a" +
            "nd moving down zooms in.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool InvertedZoomToolOperation {
            get {
                return ((bool)(this["InvertedZoomToolOperation"]));
            }
            set {
                this["InvertedZoomToolOperation"] = value;
            }
        }
        
        /// <summary>
        /// Enables match scale tool for non-parallel images.
        /// </summary>
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("Enables match scale tool for non-parallel images.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool MatchScaleForNonParallelImages {
            get {
                return ((bool)(this["MatchScaleForNonParallelImages"]));
            }
            set {
                this["MatchScaleForNonParallelImages"] = value;
            }
        }
    }
}
