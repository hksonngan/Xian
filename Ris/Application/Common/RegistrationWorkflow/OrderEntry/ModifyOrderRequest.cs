#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using ClearCanvas.Common.Serialization;
using System.Runtime.Serialization;

namespace ClearCanvas.Ris.Application.Common.RegistrationWorkflow.OrderEntry
{
    [DataContract]
    public class ModifyOrderRequest : DataContractBase
    {
        public ModifyOrderRequest(OrderRequisition requisition)
        {
            this.Requisition = requisition;
        }


        /// <summary>
        /// Requisition specifying details of the modified order.
        /// </summary>
        [DataMember]
        public OrderRequisition Requisition;

		/// <summary>
		/// Specifies that procedures will be scheduled for the time specified in <see cref="OrderRequisition.SchedulingRequestTime"/>,
		/// regardless of what is specified in individual <see cref="ProcedureRequistion"/> items.
		/// </summary>
		[DataMember]
		public bool ApplySchedulingRequestTime;
	}
}