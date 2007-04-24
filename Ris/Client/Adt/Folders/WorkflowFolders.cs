using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Tools;
using ClearCanvas.Desktop.Actions;
using ClearCanvas.Desktop.Tables;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Ris.Client;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Application.Common.RegistrationWorkflow;

namespace ClearCanvas.Ris.Client.Adt.Folders
{
    public class ScheduledFolder : RegistrationWorkflowFolder
    {
        public ScheduledFolder(RegistrationWorkflowFolderSystem folderSystem)
            : base(folderSystem, "Scheduled")
        {
            this.MenuModel = new SimpleActionModel(new ResourceResolver(this.GetType().Assembly));
            ((SimpleActionModel)this.MenuModel).AddAction("ScheduledOption", "Option", "Edit.png", "Option",
                delegate() { DisplayOption(folderSystem.DesktopWindow); });
            
            this.OpenIconSet = new IconSet(IconScheme.Colour, "OpenItemSmall.png", "OpenItemMedium.png", "OpenItemLarge.png");
            this.IconSet = this.OpenIconSet;

            this.RefreshTime = 30000;
            this.WorklistClassName = "ClearCanvas.Healthcare.Workflow.Registration.Worklists+Scheduled";
        }

        private void DisplayOption(IDesktopWindow desktopWindow)
        {
            FolderOptionComponent optionComponent = new FolderOptionComponent(this.RefreshTime);
            if (ApplicationComponent.LaunchAsDialog(desktopWindow, optionComponent, "Option") == ApplicationComponentExitCode.Normal)
            {
                this.RefreshTime = optionComponent.RefreshTime;
            }
        }
    }

    public class CheckedInFolder : RegistrationWorkflowFolder
    {
        public CheckedInFolder(RegistrationWorkflowFolderSystem folderSystem)
            : base(folderSystem, "Checked In")
        {
            this.MenuModel = new SimpleActionModel(new ResourceResolver(this.GetType().Assembly));
            ((SimpleActionModel)this.MenuModel).AddAction("ScheduledOption", "Option", "Edit.png", "Option",
                delegate() { DisplayOption(folderSystem.DesktopWindow); });

            this.RefreshTime = 30000;
            this.WorklistClassName = "ClearCanvas.Healthcare.Workflow.Registration.Worklists+CheckIn";
        }

        protected override bool CanAcceptDrop(RegistrationWorklistItem item)
        {
            return GetOperationEnablement("CheckInProcedure");
        }

        protected override bool ProcessDrop(RegistrationWorklistItem item)
        {
            RequestedProcedureCheckInComponent checkInComponent = new RequestedProcedureCheckInComponent(item);
            ApplicationComponent.LaunchAsDialog(
                this.WorkflowFolderSystem.DesktopWindow, checkInComponent, String.Format("Checking in {0}", Format.Custom(item.Name)));

            Platform.GetService<IRegistrationWorkflowService>(
                delegate(IRegistrationWorkflowService service)
                {
                    service.CheckInProcedure(new CheckInProcedureRequest(checkInComponent.SelectedRequestedProcedures));
                });
            
            return true;
        }

        private void DisplayOption(IDesktopWindow desktopWindow)
        {
            FolderOptionComponent optionComponent = new FolderOptionComponent(this.RefreshTime);
            if (ApplicationComponent.LaunchAsDialog(desktopWindow, optionComponent, "Option") == ApplicationComponentExitCode.Normal)
            {
                this.RefreshTime = optionComponent.RefreshTime;
            }
        }
    }

    public class InProgressFolder : RegistrationWorkflowFolder
    {
        public InProgressFolder(RegistrationWorkflowFolderSystem folderSystem)
            : base(folderSystem, "In Progress")
        {
            this.MenuModel = new SimpleActionModel(new ResourceResolver(this.GetType().Assembly));
            ((SimpleActionModel)this.MenuModel).AddAction("ScheduledOption", "Option", "Edit.png", "Option",
                delegate() { DisplayOption(folderSystem.DesktopWindow); });

            this.RefreshTime = 30000;
            this.WorklistClassName = "ClearCanvas.Healthcare.Workflow.Registration.Worklists+InProgress";
        }

        private void DisplayOption(IDesktopWindow desktopWindow)
        {
            FolderOptionComponent optionComponent = new FolderOptionComponent(this.RefreshTime);
            if (ApplicationComponent.LaunchAsDialog(desktopWindow, optionComponent, "Option") == ApplicationComponentExitCode.Normal)
            {
                this.RefreshTime = optionComponent.RefreshTime;
            }
        }
    }

    public class CompletedFolder : RegistrationWorkflowFolder
    {
        public CompletedFolder(RegistrationWorkflowFolderSystem folderSystem)
            : base(folderSystem, "Completed")
        {
            this.MenuModel = new SimpleActionModel(new ResourceResolver(this.GetType().Assembly));
            ((SimpleActionModel)this.MenuModel).AddAction("ScheduledOption", "Option", "Edit.png", "Option",
                delegate() { DisplayOption(folderSystem.DesktopWindow); });

            this.RefreshTime = 30000;
            this.WorklistClassName = "ClearCanvas.Healthcare.Workflow.Registration.Worklists+Completed";
        }

        private void DisplayOption(IDesktopWindow desktopWindow)
        {
            FolderOptionComponent optionComponent = new FolderOptionComponent(this.RefreshTime);
            if (ApplicationComponent.LaunchAsDialog(desktopWindow, optionComponent, "Option") == ApplicationComponentExitCode.Normal)
            {
                this.RefreshTime = optionComponent.RefreshTime;
            }
        }
    }

    public class CancelledFolder : RegistrationWorkflowFolder
    {
        public CancelledFolder(RegistrationWorkflowFolderSystem folderSystem)
            : base(folderSystem, "Cancelled")
        {
            this.MenuModel = new SimpleActionModel(new ResourceResolver(this.GetType().Assembly));
            ((SimpleActionModel)this.MenuModel).AddAction("ScheduledOption", "Option", "Edit.png", "Option",
                delegate() { DisplayOption(folderSystem.DesktopWindow); });

            this.RefreshTime = 30000;
            this.WorklistClassName = "ClearCanvas.Healthcare.Workflow.Registration.Worklists+Cancelled";
        }

        protected override bool CanAcceptDrop(RegistrationWorklistItem item)
        {
            return GetOperationEnablement("CancelOrder");
        }

        protected override bool ProcessDrop(RegistrationWorklistItem item)
        {
            CancelOrderComponent cancelOrderComponent = new CancelOrderComponent(item.PatientProfileRef);
            ApplicationComponent.LaunchAsDialog(
                this.WorkflowFolderSystem.DesktopWindow, cancelOrderComponent, String.Format("Cancel Order for {0}", Format.Custom(item.Name)));

            Platform.GetService<IRegistrationWorkflowService>(
                delegate(IRegistrationWorkflowService service)
                {
                    service.CancelOrder(new CancelOrderRequest(cancelOrderComponent.SelectedOrders, cancelOrderComponent.SelectedReason));
                });
            
            return true;
        }

        private void DisplayOption(IDesktopWindow desktopWindow)
        {
            FolderOptionComponent optionComponent = new FolderOptionComponent(this.RefreshTime);
            if (ApplicationComponent.LaunchAsDialog(desktopWindow, optionComponent, "Option") == ApplicationComponentExitCode.Normal)
            {
                this.RefreshTime = optionComponent.RefreshTime;
            }
        }
    }

    public class SearchFolder : RegistrationWorkflowFolder
    {
        private PatientProfileSearchData _searchCriteria;

        public SearchFolder(RegistrationWorkflowFolderSystem folderSystem)
            : base(folderSystem, "Search")
        {
            this.OpenIconSet = new IconSet(IconScheme.Colour, "SearchToolSmall.png", "SearchToolMedium.png", "SearchToolLarge.png");
            this.ClosedIconSet = this.OpenIconSet;
            this.IconSet = this.OpenIconSet;

            this.RefreshTime = 0;
            //this.WorklistClassName = "ClearCanvas.Healthcare.Workflow.Registration.Worklists+Search";
        }

        public PatientProfileSearchData SearchCriteria
        {
            get { return _searchCriteria; }
            set
            {
                _searchCriteria = value;
                this.Refresh();
            }
        }

        protected override bool CanQuery()
        {
            if (this.SearchCriteria != null)
                return true;

            return false;
        }

        protected override IList<RegistrationWorklistItem> QueryItems()
        {
            List<RegistrationWorklistItem> worklistItems = null;
            Platform.GetService<IRegistrationWorkflowService>(
                delegate(IRegistrationWorkflowService service)
                {
                    SearchPatientResponse response = service.SearchPatient(new SearchPatientRequest(this.SearchCriteria));
                    worklistItems = response.WorklistItems;
                });

            if (worklistItems == null)
                worklistItems = new List<RegistrationWorklistItem>();

            return worklistItems;
        }

        protected override int QueryCount()
        {
            return this.ItemCount;
        }

    }
}
