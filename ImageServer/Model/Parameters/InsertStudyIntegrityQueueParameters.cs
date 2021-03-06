#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.Xml;
using ClearCanvas.ImageServer.Enterprise;

namespace ClearCanvas.ImageServer.Model.Parameters
{
    public class InsertStudyIntegrityQueueParameters: ProcedureParameters
    {
        public InsertStudyIntegrityQueueParameters()
            : base("InsertStudyIntegrityQueue")
        {
			// This is output from the stored procedure
			SubCriteria["Inserted"] = new ProcedureParameter<bool>("Inserted");
        }
        public String StudyInstanceUid
        {
            set { SubCriteria["StudyInstanceUid"] = new ProcedureParameter<String>("StudyInstanceUid", value); }
        }
        public String Description
        {
            set { SubCriteria["Description"] = new ProcedureParameter<String>("Description", value); }
        }
        public ServerEntityKey StudyStorageKey
        {
            set { SubCriteria["StudyStorageKey"] = new ProcedureParameter<ServerEntityKey>("StudyStorageKey", value); }
        }
        public ServerEntityKey ServerPartitionKey
        {
            set { SubCriteria["ServerPartitionKey"] = new ProcedureParameter<ServerEntityKey>("ServerPartitionKey", value); }
        }
        public String SeriesInstanceUid
        {
            set { SubCriteria["SeriesInstanceUid"] = new ProcedureParameter<String>("SeriesInstanceUid", value); }
        }
        public String SopInstanceUid 
        {
            set { SubCriteria["SopInstanceUid"] = new ProcedureParameter<String>("SopInstanceUid", value); }
        }
        public String SeriesDescription
        {
            set { SubCriteria["SeriesDescription"] = new ProcedureParameter<String>("SeriesDescription", value); }
        }
        public XmlDocument StudyData
        {
            set { SubCriteria["StudyData"] = new ProcedureParameter<XmlDocument>("StudyData", value); }
        }
		public XmlDocument Details
        {
            set { SubCriteria["Details"] = new ProcedureParameter<XmlDocument>("Details", value); }
        }
        public ServerEnum StudyIntegrityReasonEnum
        {
            set { SubCriteria["StudyIntegrityReasonEnum"] = new ProcedureParameter<ServerEnum>("StudyIntegrityReasonEnum", value); }
        }
        public String GroupID
        {
            set { SubCriteria["GroupID"] = new ProcedureParameter<String>("GroupID", value); }
        }
        public String UidRelativePath
        {
            set { SubCriteria["UidRelativePath"] = new ProcedureParameter<String>("UidRelativePath", value); }
        }
		public bool Inserted
		{
			get
			{
				ProcedureParameter<bool> val = SubCriteria["Inserted"] as ProcedureParameter<bool>;
				return val == null ? false : val.Value;
			}
		}
    }
}
