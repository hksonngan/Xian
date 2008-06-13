using System.Collections.Generic;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.ImageServer.Model;
using ClearCanvas.ImageServer.Model.EntityBrokers;

namespace ClearCanvas.ImageServer.Services.WorkQueue.WebEditStudy
{
    /// <summary>
    /// Commands for updating the database when a study has been editted.
    /// </summary>
    /// <remarks>
    /// <see cref="DatabaseUpdateCommand"/> uses the <see cref="IUpdateContext"/> of the <see cref="EditStudyActionCommandBase.Context"/> to update the database.
    /// It does not, howerver, commits the transactions. The creator of the <see cref="EditStudyActionCommandBase.Context"/> is responsible for
    /// committing or rolling back the database transaction if necessary.
    /// </remarks>
    internal class DatabaseUpdateCommand : EditStudyActionCommandBase
    {
        #region Constructor
        public DatabaseUpdateCommand(string description, EditStudyContext context)
            : base(description, context)
        {
        }
        #endregion

        protected override void OnExecute()
        {
            if (Context != null && Context.UpdateContext != null)
            {
                // Update the Study
                IStudyEntityBroker studyBroker = Context.UpdateContext.GetBroker<IStudyEntityBroker>();
                studyBroker.Update(Context.Study);

                // Update the Patient
                IPatientEntityBroker patientBroker = Context.UpdateContext.GetBroker<IPatientEntityBroker>();
                patientBroker.Update(Context.Patient);

                // Update the StorageFilesystem
                IStorageFilesystemEntityBroker fsBroker = Context.UpdateContext.GetBroker<IStorageFilesystemEntityBroker>();
                StorageFilesystemUpdateColumns columns = new StorageFilesystemUpdateColumns();
                columns.StudyFolder = Context.StorageLocation.StudyFolder;

                StorageFilesystemSelectCriteria criteria = new StorageFilesystemSelectCriteria();
                criteria.StudyStorageKey.EqualTo(Context.StorageLocation.GetKey());
                IList<StorageFilesystem> listFilesystem = fsBroker.Find(criteria);
                if (listFilesystem != null)
                {
                    foreach (StorageFilesystem fs in listFilesystem)
                        fsBroker.Update(fs.GetKey(), columns);
                }

                // Update the StudyStorage
                IStudyStorageEntityBroker ssBroker = Context.UpdateContext.GetBroker<IStudyStorageEntityBroker>();
                StudyStorageUpdateColumns ssColumns = new StudyStorageUpdateColumns();
                ssColumns.StudyInstanceUid = Context.Study.StudyInstanceUid;
                ssBroker.Update(Context.StorageLocation.GetKey(), ssColumns);
            }
        }
    }
    
}
