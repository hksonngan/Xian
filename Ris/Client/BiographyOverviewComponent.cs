#region License

// Copyright (c) 2006-2007, ClearCanvas Inc.
// All rights reserved.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//    * Redistributions of source code must retain the above copyright notice, 
//      this list of conditions and the following disclaimer.
//    * Redistributions in binary form must reproduce the above copyright notice, 
//      this list of conditions and the following disclaimer in the documentation 
//      and/or other materials provided with the distribution.
//    * Neither the name of ClearCanvas Inc. nor the names of its contributors 
//      may be used to endorse or promote products derived from this software without 
//      specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
// AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, 
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
// PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR 
// CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, 
// OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE 
// GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) 
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, 
// STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN 
// ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.

#endregion

using System;
using System.Collections.Generic;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Tools;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Client.Formatting;

namespace ClearCanvas.Ris.Client
{
    /// <summary>
    /// Extension point for views onto <see cref="BiographyOverviewComponent"/>
    /// </summary>
    [ExtensionPoint]
    public class BiographyOverviewComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
    {
    }

    [ExtensionPoint]
    public class PatientBiographyToolExtensionPoint : ExtensionPoint<ITool>
    {
    }

    public interface IPatientBiographyToolContext : IToolContext
    {
        EntityRef PatientRef { get; }
        EntityRef PatientProfileRef { get; }
        IDesktopWindow DesktopWindow { get; }
    }

    public class AlertListItem
    {
        public AlertListItem(string name, string message, string icon)
        {
            this.Name = name;
            this.Message = message;
            this.Icon = icon;
        }

        public string Name;
        public string Message;
        public string Icon;
    }

    /// <summary>
    /// PatientComponent class
    /// </summary>
    [AssociateView(typeof(BiographyOverviewComponentViewExtensionPoint))]
    public class BiographyOverviewComponent : ApplicationComponent
    {
        class PatientBiographyToolContext : ToolContext, IPatientBiographyToolContext
        {
            private readonly BiographyOverviewComponent _component;

            internal PatientBiographyToolContext(BiographyOverviewComponent component)
            {
                _component = component;
            }

            public EntityRef PatientRef
            {
                get { return _component._patientRef; }
            }

            public EntityRef PatientProfileRef
            {
                get { return _component._profileRef; }
            }

            public IDesktopWindow DesktopWindow
            {
                get { return _component.Host.DesktopWindow; }
            }
        }

        private readonly EntityRef _patientRef;
        private readonly EntityRef _profileRef;
        private readonly PatientProfileDetail _patientProfile;
        private readonly List<AlertNotificationDetail> _alertNotifications;

        private ToolSet _toolSet;
        private readonly ResourceResolver _resourceResolver;

        /// <summary>
        /// Constructor
        /// </summary>
        public BiographyOverviewComponent(
            EntityRef patientRef,
            EntityRef profileRef, 
            PatientProfileDetail patientProfile, 
            List<AlertNotificationDetail> alertNotifications)
        {
            _patientRef = patientRef;
            _profileRef = profileRef;
            _patientProfile = patientProfile;
            _alertNotifications = alertNotifications;

            _resourceResolver = new ResourceResolver(this.GetType().Assembly);
        }

        public override void Start()
        {
            _toolSet = new ToolSet(new PatientBiographyToolExtensionPoint(), new PatientBiographyToolContext(this));

            base.Start();
        }

        public override void Stop()
        {
            _toolSet.Dispose();
            base.Stop();
        }

        public override IActionSet ExportedActions
        {
            get { return _toolSet.Actions; }
        }

        #region Presentation Model

        public string Name
        {
            get { return PersonNameFormat.Format(_patientProfile.Name); }
        }

        public string Mrn
        {
            get { return String.Format("Mrn: {0}", MrnFormat.Format(_patientProfile.Mrn)); }
        }

        public string HealthCard
        {
            get { return _patientProfile == null ? "" : 
                String.Format("Healthcard: {0}", HealthcardFormat.Format(_patientProfile.Healthcard)); }
        }

        public string AgeSex
        {
            get 
            {
                if (_patientProfile.DeathIndicator)
                {
                    TimeSpan age = _patientProfile.TimeOfDeath.Value.Subtract(_patientProfile.DateOfBirth.Value);
                    return String.Format("Age/Sex: {0} ({1}) Deceased", age.Days / 365, _patientProfile.Sex.Value);
                }
                else
                {
                    TimeSpan age = Platform.Time.Date.Subtract(_patientProfile.DateOfBirth.Value);
                    return String.Format("Age/Sex: {0} ({1})", age.Days / 365, _patientProfile.Sex.Value);
                }
            }
        }

        public string DateOfBirth
        {
            get { return String.Format("DOB: {0}", Format.Date(_patientProfile.DateOfBirth)); }
        }

        public ResourceResolver ResourceResolver
        {
            get { return _resourceResolver; }
        }

        public string PatientImage
        {
            get { return "AlertMessenger.png"; }
        }

        public List<AlertListItem> AlertList
        {
            get 
            {
                List<AlertListItem> alertListItems = new List<AlertListItem>();

                foreach (AlertNotificationDetail detail in _alertNotifications)
                {
                    alertListItems.Add(new AlertListItem(detail.Type, GetAlertTooltip(detail), GetAlertIcon(detail)));
                }

                return alertListItems;
            }
        }

        #endregion

        private static string GetAlertIcon(AlertNotificationDetail detail)
        {
            string icon;

            switch (detail.Type)
            {
                case "Note Alert":
                    icon = "AlertPen.png";
                    break;
                case "Language Alert":
                    icon = "AlertWorld.png";
                    break;
                case "Reconciliation Alert":
                    icon = "AlertMessenger.png";
                    break;
                case "Incomplete Demographic Data Alert":
                    icon = "AlertIncompleteData.png";
                    break;
                case "Visit Alert":
                    icon = "AlertClock.png";
                    break;
                default:
                    icon = "AlertGeneral.png";
                    break;
            }

            return icon;
        }

        private string GetAlertTooltip(AlertNotificationDetail detail)
        {
            string alertTooltip;
            string patientName = PersonNameFormat.Format(_patientProfile.Name, "%g. %F");

            switch (detail.Type)
            {
                case "Note Alert":
                    alertTooltip = String.Format(SR.MessageAlertHighSeverityNote
                        , patientName
                        , StringUtilities.Combine(detail.Reasons, ", "));
                    break;
                case "Language Alert":
                    alertTooltip = String.Format(SR.MessageAlertLanguageNotEnglish
                        , patientName
                        , StringUtilities.Combine(detail.Reasons, ", "));
                    break;
                case "Reconciliation Alert":
                    alertTooltip = String.Format(SR.MessageAlertUnreconciledRecords, patientName);
                    break;
                case "Incomplete Demographic Data Alert":
                    alertTooltip = String.Format(SR.MessageAlertIncompleteDemographicData
                        , patientName,
                        StringUtilities.Combine(detail.Reasons, ", "));
                    break;
                case "Visit Alert":
                    alertTooltip = String.Format(SR.MessageAlertInvalidVisit
                        , StringUtilities.Combine(detail.Reasons, ", "));
                    break;
                default:
                    alertTooltip = StringUtilities.Combine(detail.Reasons, ", ");
                    break;
            }

            return alertTooltip;
        }
    }
}
