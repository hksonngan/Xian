#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0//

#endregion

// This file is auto-generated by the ClearCanvas.Model.SqlServer.CodeGenerator project.

namespace ClearCanvas.ImageServer.Model
{
    using System;
    using System.Xml;
    using ClearCanvas.Enterprise.Core;
    using ClearCanvas.ImageServer.Enterprise;
    using ClearCanvas.ImageServer.Model.EntityBrokers;

    [Serializable]
    public partial class ServiceLock: ServerEntity
    {
        #region Constructors
        public ServiceLock():base("ServiceLock")
        {}
        public ServiceLock(
             ServiceLockTypeEnum _serviceLockTypeEnum_
            ,Boolean _lock_
            ,DateTime _scheduledTime_
            ,Boolean _enabled_
            ,XmlDocument _state_
            ,ServerEntityKey _filesystemKey_
            ,String _processorId_
            ):base("ServiceLock")
        {
            ServiceLockTypeEnum = _serviceLockTypeEnum_;
            Lock = _lock_;
            ScheduledTime = _scheduledTime_;
            Enabled = _enabled_;
            State = _state_;
            FilesystemKey = _filesystemKey_;
            ProcessorId = _processorId_;
        }
        #endregion

        #region Public Properties
        [EntityFieldDatabaseMappingAttribute(TableName="ServiceLock", ColumnName="ServiceLockTypeEnum")]
        public ServiceLockTypeEnum ServiceLockTypeEnum
        { get; set; }
        [EntityFieldDatabaseMappingAttribute(TableName="ServiceLock", ColumnName="Lock")]
        public Boolean Lock
        { get; set; }
        [EntityFieldDatabaseMappingAttribute(TableName="ServiceLock", ColumnName="ScheduledTime")]
        public DateTime ScheduledTime
        { get; set; }
        [EntityFieldDatabaseMappingAttribute(TableName="ServiceLock", ColumnName="Enabled")]
        public Boolean Enabled
        { get; set; }
        [EntityFieldDatabaseMappingAttribute(TableName="ServiceLock", ColumnName="State")]
        public XmlDocument State
        { get { return _State; } set { _State = value; } }
        [NonSerialized]
        private XmlDocument _State;
        [EntityFieldDatabaseMappingAttribute(TableName="ServiceLock", ColumnName="FilesystemGUID")]
        public ServerEntityKey FilesystemKey
        { get; set; }
        [EntityFieldDatabaseMappingAttribute(TableName="ServiceLock", ColumnName="ProcessorId")]
        public String ProcessorId
        { get; set; }
        #endregion

        #region Static Methods
        static public ServiceLock Load(ServerEntityKey key)
        {
            using (var read = PersistentStoreRegistry.GetDefaultStore().OpenReadContext())
            {
                return Load(read, key);
            }
        }
        static public ServiceLock Load(IPersistenceContext read, ServerEntityKey key)
        {
            var broker = read.GetBroker<IServiceLockEntityBroker>();
            ServiceLock theObject = broker.Load(key);
            return theObject;
        }
        static public ServiceLock Insert(ServiceLock entity)
        {
            using (var update = PersistentStoreRegistry.GetDefaultStore().OpenUpdateContext(UpdateContextSyncMode.Flush))
            {
                ServiceLock newEntity = Insert(update, entity);
                update.Commit();
                return newEntity;
            }
        }
        static public ServiceLock Insert(IUpdateContext update, ServiceLock entity)
        {
            var broker = update.GetBroker<IServiceLockEntityBroker>();
            var updateColumns = new ServiceLockUpdateColumns();
            updateColumns.ServiceLockTypeEnum = entity.ServiceLockTypeEnum;
            updateColumns.Lock = entity.Lock;
            updateColumns.ScheduledTime = entity.ScheduledTime;
            updateColumns.Enabled = entity.Enabled;
            updateColumns.State = entity.State;
            updateColumns.FilesystemKey = entity.FilesystemKey;
            updateColumns.ProcessorId = entity.ProcessorId;
            ServiceLock newEntity = broker.Insert(updateColumns);
            return newEntity;
        }
        #endregion
    }
}
