#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.ServiceModel;
using ClearCanvas.Enterprise.Common;

namespace ClearCanvas.Ris.Application.Common.Admin.ProcedureTypeAdmin
{
	/// <summary>
	/// Provides operations to administer ProcedureType entities.
	/// </summary>
	[RisApplicationService]
	[ServiceContract]
	public interface IProcedureTypeAdminService
	{
		/// <summary>
		/// Returns a list of procedure type based on a textual query.
		/// </summary>
		/// <param name="request"></param>
		/// <returns></returns>
		[OperationContract]
		TextQueryResponse<ProcedureTypeSummary> TextQuery(TextQueryRequest request);

		/// <summary>
		/// Summary list of all items.
		/// </summary>
		[OperationContract]
		ListProcedureTypesResponse ListProcedureTypes(ListProcedureTypesRequest request);

		/// <summary>
		/// Loads details of specified item for editing.
		/// </summary>
		[OperationContract]
		LoadProcedureTypeForEditResponse LoadProcedureTypeForEdit(LoadProcedureTypeForEditRequest request);

		/// <summary>
		/// Loads all form data needed to edit an item.
		/// </summary>
		[OperationContract]
		LoadProcedureTypeEditorFormDataResponse LoadProcedureTypeEditorFormData(LoadProcedureTypeEditorFormDataRequest request);

		/// <summary>
		/// Adds a new item.
		/// </summary>
		[OperationContract]
		[FaultContract(typeof(RequestValidationException))]
		AddProcedureTypeResponse AddProcedureType(AddProcedureTypeRequest request);

		/// <summary>
		/// Updates an item.
		/// </summary>
		[OperationContract]
		[FaultContract(typeof(ConcurrentModificationException))]
		[FaultContract(typeof(RequestValidationException))]
		UpdateProcedureTypeResponse UpdateProcedureType(UpdateProcedureTypeRequest request);

		/// <summary>
		/// Deletes an item.
		/// </summary>
		[OperationContract]
		[FaultContract(typeof(ConcurrentModificationException))]
		[FaultContract(typeof(RequestValidationException))]
		DeleteProcedureTypeResponse DeleteProcedureType(DeleteProcedureTypeRequest request);
	}
}
