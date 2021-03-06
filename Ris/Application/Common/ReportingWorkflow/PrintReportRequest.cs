#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using ClearCanvas.Common.Serialization;
using ClearCanvas.Enterprise.Common;
using System.Runtime.Serialization;

namespace ClearCanvas.Ris.Application.Common.ReportingWorkflow
{
	[DataContract]
	public class PrintReportRequest : DataContractBase
	{
		public PrintReportRequest(EntityRef reportRef)
		{
			this.ReportRef = reportRef;
		}

		/// <summary>
		/// Specify the report to be printed.
		/// </summary>
		[DataMember]
		public EntityRef ReportRef;

		/// <summary>
		/// Optionally specify a recipient contact point.  If not specified, the ordering practitioner will be used.
		/// </summary>
		[DataMember]
		public EntityRef RecipientContactPointRef;
	}
}
