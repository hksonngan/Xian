﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.5446
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClearCanvas.Enterprise.Authentication {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
    internal sealed partial class PasswordResetEmailSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static PasswordResetEmailSettings defaultInstance = ((PasswordResetEmailSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new PasswordResetEmailSettings())));
        
        public static PasswordResetEmailSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Your password has been reset")]
        public string SubjectTemplate {
            get {
                return ((string)(this["SubjectTemplate"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"
<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Transitional//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd""> 
 
<html xmlns=""http://www.w3.org/1999/xhtml""> <body>Dear $USER,<br/><br>Your new temporary password to the Web Portal is:<br/>
<br/>
 <b>$PASSWORD</b>
<br/>
<br/>You will be required to reset your password the next time you login the system.</body></html>")]
        public string BodyTemplate {
            get {
                return ((string)(this["BodyTemplate"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("noreply@example.com")]
        public string FromAddress {
            get {
                return ((string)(this["FromAddress"]));
            }
        }
    }
}