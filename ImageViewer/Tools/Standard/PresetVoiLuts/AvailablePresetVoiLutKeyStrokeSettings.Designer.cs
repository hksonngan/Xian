﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.ImageViewer.Tools.Standard.PresetVoiLuts {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class AvailablePresetVoiLutKeyStrokeSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static AvailablePresetVoiLutKeyStrokeSettings defaultInstance = ((AvailablePresetVoiLutKeyStrokeSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new AvailablePresetVoiLutKeyStrokeSettings())));
        
        public static AvailablePresetVoiLutKeyStrokeSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        /// <summary>
        /// A list of keystrokes to use for user-defined LUT (e.g. window/level) presets.
        /// </summary>
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Configuration.SettingsDescriptionAttribute("A list of keystrokes to use for user-defined LUT (e.g. window/level) presets.")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>F3</string>
  <string>F4</string>
  <string>F5</string>
  <string>F6</string>
  <string>F7</string>
  <string>F8</string>
  <string>F9</string>
  <string>F10</string>
  <string>F11</string>
  <string>F12</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection AvailableKeyStrokes {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["AvailableKeyStrokes"]));
            }
        }
    }
}
