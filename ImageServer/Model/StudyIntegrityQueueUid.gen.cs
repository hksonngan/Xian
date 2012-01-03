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
    using ClearCanvas.Dicom;
    using ClearCanvas.Enterprise.Core;
    using ClearCanvas.ImageServer.Enterprise;
    using ClearCanvas.ImageServer.Model.EntityBrokers;

    [Serializable]
    public partial class StudyIntegrityQueueUid: ServerEntity
    {
        #region Constructors
        public StudyIntegrityQueueUid():base("StudyIntegrityQueueUid")
        {}
        public StudyIntegrityQueueUid(
             ServerEntityKey _studyIntegrityQueueKey_
            ,String _seriesInstanceUid_
            ,String _sopInstanceUid_
            ,String _relativePath_
            ,String _seriesDescription_
            ):base("StudyIntegrityQueueUid")
        {
            StudyIntegrityQueueKey = _studyIntegrityQueueKey_;
            SeriesInstanceUid = _seriesInstanceUid_;
            SopInstanceUid = _sopInstanceUid_;
            RelativePath = _relativePath_;
            SeriesDescription = _seriesDescription_;
        }
        #endregion

        #region Public Properties
        [EntityFieldDatabaseMappingAttribute(TableName="StudyIntegrityQueueUid", ColumnName="StudyIntegrityQueueGUID")]
        public ServerEntityKey StudyIntegrityQueueKey
        { get; set; }
        [DicomField(DicomTags.SeriesInstanceUid, DefaultValue = DicomFieldDefault.Null)]
        [EntityFieldDatabaseMappingAttribute(TableName="StudyIntegrityQueueUid", ColumnName="SeriesInstanceUid")]
        public String SeriesInstanceUid
        { get; set; }
        [DicomField(DicomTags.SopInstanceUid, DefaultValue = DicomFieldDefault.Null)]
        [EntityFieldDatabaseMappingAttribute(TableName="StudyIntegrityQueueUid", ColumnName="SopInstanceUid")]
        public String SopInstanceUid
        { get; set; }
        [EntityFieldDatabaseMappingAttribute(TableName="StudyIntegrityQueueUid", ColumnName="RelativePath")]
        public String RelativePath
        { get; set; }
        [DicomField(DicomTags.SeriesDescription, DefaultValue = DicomFieldDefault.Null)]
        [EntityFieldDatabaseMappingAttribute(TableName="StudyIntegrityQueueUid", ColumnName="SeriesDescription")]
        public String SeriesDescription
        { get; set; }
        #endregion

        #region Static Methods
        static public StudyIntegrityQueueUid Load(ServerEntityKey key)
        {
            using (var read = PersistentStoreRegistry.GetDefaultStore().OpenReadContext())
            {
                return Load(read, key);
            }
        }
        static public StudyIntegrityQueueUid Load(IPersistenceContext read, ServerEntityKey key)
        {
            var broker = read.GetBroker<IStudyIntegrityQueueUidEntityBroker>();
            StudyIntegrityQueueUid theObject = broker.Load(key);
            return theObject;
        }
        static public StudyIntegrityQueueUid Insert(StudyIntegrityQueueUid entity)
        {
            using (var update = PersistentStoreRegistry.GetDefaultStore().OpenUpdateContext(UpdateContextSyncMode.Flush))
            {
                StudyIntegrityQueueUid newEntity = Insert(update, entity);
                update.Commit();
                return newEntity;
            }
        }
        static public StudyIntegrityQueueUid Insert(IUpdateContext update, StudyIntegrityQueueUid entity)
        {
            var broker = update.GetBroker<IStudyIntegrityQueueUidEntityBroker>();
            var updateColumns = new StudyIntegrityQueueUidUpdateColumns();
            updateColumns.StudyIntegrityQueueKey = entity.StudyIntegrityQueueKey;
            updateColumns.SeriesInstanceUid = entity.SeriesInstanceUid;
            updateColumns.SopInstanceUid = entity.SopInstanceUid;
            updateColumns.RelativePath = entity.RelativePath;
            updateColumns.SeriesDescription = entity.SeriesDescription;
            StudyIntegrityQueueUid newEntity = broker.Insert(updateColumns);
            return newEntity;
        }
        #endregion
    }
}
