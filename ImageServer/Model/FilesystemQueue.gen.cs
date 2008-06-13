#region License

// Copyright (c) 2006-2008, ClearCanvas Inc.
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

// This file is auto-generated by the ClearCanvas.Model.SqlServer2005.CodeGenerator project.

namespace ClearCanvas.ImageServer.Model
{
    using System;
    using ClearCanvas.Dicom;
    using ClearCanvas.Enterprise.Core;
    using ClearCanvas.ImageServer.Enterprise;
    using ClearCanvas.ImageServer.Model.EntityBrokers;

    [Serializable]
    public partial class FilesystemQueue: ServerEntity
    {
        #region Constructors
        public FilesystemQueue():base("FilesystemQueue")
        {}
        #endregion

        #region Private Members
        private ClearCanvas.ImageServer.Enterprise.ServerEntityKey _filesystemKey;
        private FilesystemQueueTypeEnum _filesystemQueueTypeEnum;
        private System.Xml.XmlDocument _queueXml;
        private System.DateTime _scheduledTime;
        private System.String _seriesInstanceUid;
        private ClearCanvas.ImageServer.Enterprise.ServerEntityKey _studyStorageKey;
        #endregion

        #region Public Properties
        [EntityFieldDatabaseMappingAttribute(TableName="FilesystemQueue", ColumnName="FilesystemGUID")]
        public ClearCanvas.ImageServer.Enterprise.ServerEntityKey FilesystemKey
        {
        get { return _filesystemKey; }
        set { _filesystemKey = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="FilesystemQueue", ColumnName="FilesystemQueueTypeEnum")]
        public FilesystemQueueTypeEnum FilesystemQueueTypeEnum
        {
        get { return _filesystemQueueTypeEnum; }
        set { _filesystemQueueTypeEnum = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="FilesystemQueue", ColumnName="QueueXml")]
        public System.Xml.XmlDocument QueueXml
        {
        get { return _queueXml; }
        set { _queueXml = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="FilesystemQueue", ColumnName="ScheduledTime")]
        public System.DateTime ScheduledTime
        {
        get { return _scheduledTime; }
        set { _scheduledTime = value; }
        }
        [DicomField(DicomTags.SeriesInstanceUid, DefaultValue = DicomFieldDefault.Null)]
        [EntityFieldDatabaseMappingAttribute(TableName="FilesystemQueue", ColumnName="SeriesInstanceUid")]
        public System.String SeriesInstanceUid
        {
        get { return _seriesInstanceUid; }
        set { _seriesInstanceUid = value; }
        }
        [EntityFieldDatabaseMappingAttribute(TableName="FilesystemQueue", ColumnName="StudyStorageGUID")]
        public ClearCanvas.ImageServer.Enterprise.ServerEntityKey StudyStorageKey
        {
        get { return _studyStorageKey; }
        set { _studyStorageKey = value; }
        }
        #endregion

        #region Static Methods
        static public FilesystemQueue Load(ServerEntityKey key)
        {
            using (IReadContext read = PersistentStoreRegistry.GetDefaultStore().OpenReadContext())
            {
                return Load(read, key);
            }
        }
        static public FilesystemQueue Load(IReadContext read, ServerEntityKey key)
        {
            IFilesystemQueueEntityBroker broker = read.GetBroker<IFilesystemQueueEntityBroker>();
            FilesystemQueue theObject = broker.Load(key);
            return theObject;
        }
        #endregion
    }
}
