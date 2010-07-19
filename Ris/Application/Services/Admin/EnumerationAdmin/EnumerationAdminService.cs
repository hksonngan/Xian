﻿#region License

// Copyright (c) 2010, ClearCanvas Inc.
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
using System.Security.Permissions;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Common;
using ClearCanvas.Enterprise.Core;
using ClearCanvas.Enterprise.Core.Modelling;
using ClearCanvas.Ris.Application.Common.Admin.EnumerationAdmin;
using AuthorityTokens=ClearCanvas.Ris.Application.Common.AuthorityTokens;

namespace ClearCanvas.Ris.Application.Services.Admin.EnumerationAdmin
{
	[ExtensionOf(typeof(ApplicationServiceExtensionPoint))]
	[ServiceImplementsContract(typeof(IEnumerationAdminService))]
	public class EnumerationAdminService : ApplicationServiceBase, IEnumerationAdminService
	{
		#region IEnumerationAdminService Members

		[ReadOperation]
		public ListEnumerationsResponse ListEnumerations(ListEnumerationsRequest request)
		{
			var broker = PersistenceContext.GetBroker<IMetadataBroker>();
			var enumClasses = broker.ListEnumValueClasses();

			var enumerations = CollectionUtils.Map<Type, EnumerationSummary, List<EnumerationSummary>>(enumClasses,
				enumClass => new EnumerationSummary(enumClass.AssemblyQualifiedName, enumClass.Name, IsSoftEnum(enumClass)));

			return new ListEnumerationsResponse(enumerations);
		}

		[ReadOperation]
		public ListEnumerationValuesResponse ListEnumerationValues(ListEnumerationValuesRequest request)
		{
			var enumBroker = PersistenceContext.GetBroker<IEnumBroker>();
			var enumValues = enumBroker.Load(GetEnumClass(request.AssemblyQualifiedClassName), request.IncludeDeactivated);
			return new ListEnumerationValuesResponse(
				CollectionUtils.Map(enumValues, 
				(EnumValue value) => new EnumValueAdminInfo(value.Code, value.Value, value.Description, value.Deactivated)));
		}

		[UpdateOperation]
		[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.Enumeration)]
		public AddValueResponse AddValue(AddValueRequest request)
		{
			Platform.CheckForNullReference(request, "request");
			Platform.CheckMemberIsSet(request.Value, "Value");

			var enumClass = GetEnumClass(request.AssemblyQualifiedClassName);

			// compute a display order for the new value
			var displayOrder = ComputeDisplayOrderValue(enumClass, request.Value.Code,
				request.InsertAfter == null ? null : request.InsertAfter.Code);

			// add the new value
			var broker = PersistenceContext.GetBroker<IEnumBroker>();
			broker.AddValue(enumClass, request.Value.Code, request.Value.Value, request.Value.Description, displayOrder,
				IsSoftEnum(enumClass) ? request.Value.Deactivated : false);

			return new AddValueResponse();
		}

		[UpdateOperation]
		[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.Enumeration)]
		public EditValueResponse EditValue(EditValueRequest request)
		{
			Platform.CheckForNullReference(request, "request");
			Platform.CheckMemberIsSet(request.Value, "Value");

			var enumClass = GetEnumClass(request.AssemblyQualifiedClassName);

			// compute display order value
			var displayOrder = ComputeDisplayOrderValue(enumClass, request.Value.Code,
				request.InsertAfter == null ? null : request.InsertAfter.Code);

			var broker = PersistenceContext.GetBroker<IEnumBroker>();
			broker.UpdateValue(enumClass, request.Value.Code, request.Value.Value, request.Value.Description, displayOrder,
				IsSoftEnum(enumClass) ? request.Value.Deactivated : false);

			return new EditValueResponse();
		}

		[UpdateOperation]
		[PrincipalPermission(SecurityAction.Demand, Role = AuthorityTokens.Admin.Data.Enumeration)]
		public RemoveValueResponse RemoveValue(RemoveValueRequest request)
		{
			Type enumClass = null;
			
			try
			{
				enumClass = GetEnumClass(request.AssemblyQualifiedClassName);

			// Client side should enforce this.  But just in case it does not.
			if (IsSoftEnum(enumClass) == false)
				throw new RequestValidationException(SR.ExceptionUnableToDeleteHardEnumeration);

				var broker = PersistenceContext.GetBroker<IEnumBroker>();
				broker.RemoveValue(enumClass, request.Value.Code);
				PersistenceContext.SynchState();
				return new RemoveValueResponse();
			}
			catch (PersistenceException)
			{
				throw new RequestValidationException(string.Format(SR.ExceptionFailedToDelete, TerminologyTranslator.Translate(enumClass)));
			}
		}

		#endregion

		private static Type GetEnumClass(string enumerationName)
		{
			var enumClass = Type.GetType(enumerationName);
			if (enumClass == null)
				throw new RequestValidationException("Invalid enumeration name.");

			return enumClass;
		}

		private static bool IsSoftEnum(Type enumClass)
		{
			return !CollectionUtils.Contains(enumClass.Assembly.GetTypes(),
				t => t.IsEnum && AttributeUtils.HasAttribute<EnumValueClassAttribute>(t, false, attr => attr.EnumValueClass.Equals(enumClass)));
		}

		private float ComputeDisplayOrderValue(Type enumValueClass, string code, string insertAfterCode)
		{
			var broker = PersistenceContext.GetBroker<IEnumBroker>();

			// get insertAfter value, which may be null if the value is to be inserted at the beginning
			var insertAfter = insertAfterCode == null ? null : broker.Find(enumValueClass, insertAfterCode);
			if (insertAfter != null && insertAfter.Code == code)
				throw new RequestValidationException("Value cannot be inserted after itself.");

			// get the insertBefore value (the value immediately following insertAfter)
			// this may be null if insertAfter is the last value in the set
			var values = broker.Load(enumValueClass, true);
			var insertAfterIndex = insertAfter == null ? -1 : values.IndexOf(insertAfter);
			var insertBefore = (insertAfterIndex + 1 == values.Count) ? null : values[insertAfterIndex + 1];

			// if the insertBefore value is the same as the value being edited, then there is no change in displayOrder
			if (insertBefore != null && insertBefore.Code == code)
				return insertBefore.DisplayOrder;

			// otherwise compute a new display order value
			var lower = insertAfter == null ? 0 : insertAfter.DisplayOrder;
			return insertBefore == null ? lower + 1 : (lower + insertBefore.DisplayOrder) / 2;
		}
	}
}
