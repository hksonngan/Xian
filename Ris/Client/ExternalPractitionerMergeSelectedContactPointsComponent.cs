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

using System;
using System.Collections.Generic;
using ClearCanvas.Common;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Desktop;
using ClearCanvas.Desktop.Tables;
using ClearCanvas.Desktop.Validation;
using ClearCanvas.Ris.Application.Common;
using ClearCanvas.Ris.Client.Formatting;

namespace ClearCanvas.Ris.Client
{
	/// <summary>
	/// Extension point for views onto <see cref="ExternalPractitionerMergeSelectedContactPointsComponent"/>.
	/// </summary>
	[ExtensionPoint]
	public sealed class ExternalPractitionerMergeSelectedContactPointsComponentViewExtensionPoint : ExtensionPoint<IApplicationComponentView>
	{
	}

	/// <summary>
	/// ExternalPractitionerMergeSelectedContactPointsComponent class.
	/// </summary>
	[AssociateView(typeof(ExternalPractitionerMergeSelectedContactPointsComponentViewExtensionPoint))]
	public class ExternalPractitionerMergeSelectedContactPointsComponent : ApplicationComponent
	{
		private class ExternalPractitionerContactPointTable : Table<ExternalPractitionerContactPointDetail>
		{
			private const int NumRows = 5;
			private const int PhoneRow = 1;
			private const int FaxRow = 2;
			private const int AddressRow = 3;
			private const int EmailRow = 4;

			private event EventHandler _tableModified;

			public ExternalPractitionerContactPointTable()
				: base(NumRows)
			{
				var activeColumn = new TableColumn<ExternalPractitionerContactPointDetail, bool>(SR.ColumnActive,
					cp => !cp.Deactivated, SetDeactivatedStatus, 0.1f);

				var defaultColumn = new TableColumn<ExternalPractitionerContactPointDetail, bool>(SR.ColumnDefault,
					cp => cp.IsDefaultContactPoint, MakeDefaultContactPoint, 0.1f);

				var nameColumn = new TableColumn<ExternalPractitionerContactPointDetail, string>(SR.ColumnName,
					cp => cp.Name, 0.4f);

				var descriptionColumn = new TableColumn<ExternalPractitionerContactPointDetail, string>(SR.ColumnDescription,
					cp => cp.Description, 0.4f);

				var phoneColumn = new TableColumn<ExternalPractitionerContactPointDetail, string>(SR.ColumnPhone,
					cp => string.Format(SR.FormatPhone, cp.CurrentPhoneNumber == null ? "" : TelephoneFormat.Format(cp.CurrentPhoneNumber)),
					1.0f, PhoneRow);

				var faxColumn = new TableColumn<ExternalPractitionerContactPointDetail, string>(SR.ColumnFax,
					cp => string.Format(SR.FormatFax, cp.CurrentFaxNumber == null ? "" : TelephoneFormat.Format(cp.CurrentFaxNumber)),
					1.0f, FaxRow);

				var addressColumn = new TableColumn<ExternalPractitionerContactPointDetail, string>(SR.ColumnAddress,
					cp => string.Format(SR.FormatAddress, cp.CurrentAddress == null ? "" : AddressFormat.Format(cp.CurrentAddress)),
					1.0f, AddressRow);

				var emailColumn = new TableColumn<ExternalPractitionerContactPointDetail, string>(SR.ColumnEmail,
					cp => string.Format(SR.FormatEmail, cp.CurrentEmailAddress == null ? "" : cp.CurrentEmailAddress.Address),
					1.0f, EmailRow);

				this.Columns.Add(activeColumn);
				this.Columns.Add(defaultColumn);
				this.Columns.Add(nameColumn);
				this.Columns.Add(descriptionColumn);
				this.Columns.Add(phoneColumn);
				this.Columns.Add(faxColumn);
				this.Columns.Add(addressColumn);
				this.Columns.Add(emailColumn);
			}

			public event EventHandler TableModified
			{
				add { _tableModified += value; }
				remove { _tableModified -= value; }
			}

			public void MakeDefaultContactPoint(ExternalPractitionerContactPointDetail cp, bool value)
			{
				if (cp == null)
					return;

				// Make sure only one contact point is checked as the default.
				foreach (var item in this.Items)
				{
					item.IsDefaultContactPoint = item == cp ? value : false;
					this.Items.NotifyItemUpdated(item);
				}

				EventsHelper.Fire(_tableModified, this, EventArgs.Empty);
			}

			private void SetDeactivatedStatus(ExternalPractitionerContactPointDetail cp, bool value)
			{
				cp.Deactivated = !value;
				EventsHelper.Fire(_tableModified, this, EventArgs.Empty);
			}
		}

		private readonly ExternalPractitionerContactPointTable _table;
		private readonly List<ExternalPractitionerContactPointDetail> _deactivatedContactPointNotShown;
		private ExternalPractitionerContactPointDetail _selectedItem;

		private ExternalPractitionerDetail _originalPractitioner;
		private ExternalPractitionerDetail _duplicatePractitioner;

		public ExternalPractitionerMergeSelectedContactPointsComponent()
		{
			_table = new ExternalPractitionerContactPointTable();
			_deactivatedContactPointNotShown = new List<ExternalPractitionerContactPointDetail>();
		}

		public override void Start()
		{
			this.Validation.Add(new ValidationRule("SummarySelection",
				component => new ValidationResult(this.ActiveContactPoints.Count > 0, SR.MessageValidationAtLeastOneActiveContactPoint)));

			this.Validation.Add(new ValidationRule("SummarySelection",
				component => new ValidationResult(this.DefaultContactPoint != null, SR.MessageValidationMustHaveOneDefaultContactPoint)));

			this.Validation.Add(new ValidationRule("SummarySelection",
				component => new ValidationResult(this.DefaultContactPoint == null ? true : this.DefaultContactPoint.Deactivated == false, SR.MessageValidationDefaultContactPointMustBeActive)));

			_table.TableModified += ((sender, e) => this.ShowValidation(true));

			base.Start();
		}

		public ExternalPractitionerDetail OriginalPractitioner
		{
			get { return _originalPractitioner; }
			set
			{
				if (_originalPractitioner != null && _originalPractitioner.Equals(value))
					return;

				_originalPractitioner = value;
				UpdateContactPointsTable();
			}
		}

		public ExternalPractitionerDetail DuplicatePractitioner
		{
			get { return _duplicatePractitioner; }
			set
			{
				if (_originalPractitioner != null && _originalPractitioner.Equals(value))
					return;

				_duplicatePractitioner = value;
				UpdateContactPointsTable();
			}
		}

		public ExternalPractitionerContactPointDetail DefaultContactPoint
		{
			get { return CollectionUtils.SelectFirst(_table.Items, cp => cp.IsDefaultContactPoint); }
		}

		public List<ExternalPractitionerContactPointDetail> ActiveContactPoints
		{
			get { return CollectionUtils.Select(_table.Items, cp => cp.Deactivated == false); }
		}

		public List<ExternalPractitionerContactPointDetail> DeactivatedContactPoints
		{
			get { return CollectionUtils.Select(_table.Items, cp => cp.Deactivated); }
		}

		public void Save(ExternalPractitionerDetail practitioner)
		{
			practitioner.ContactPoints.Clear();

			// Add the originally deactivated contact points
			practitioner.ContactPoints.AddRange(_deactivatedContactPointNotShown);

			// Add the items in the table.
			practitioner.ContactPoints.AddRange(_table.Items);
		}

		#region Presentation Models

		public string Instruction
		{
			get { return SR.MessageInstructionSelectContactPoints; }
		}

		public ITable ContactPointTable
		{
			get { return _table; }
		}

		public ISelection SummarySelection
		{
			get { return new Selection(_selectedItem); }
			set { _selectedItem = (ExternalPractitionerContactPointDetail)value.Item; }
		}

		#endregion

		private void UpdateContactPointsTable()
		{
			if (_originalPractitioner == null || _duplicatePractitioner == null)
				return;

			var combinedContactPoints = new List<ExternalPractitionerContactPointDetail>();

			// Clone each contact points.  Do not alter the original copy.
			foreach (var cp in _originalPractitioner.ContactPoints)
				combinedContactPoints.Add((ExternalPractitionerContactPointDetail)cp.Clone());

			var originalDefaultContactPoint = CollectionUtils.SelectFirst(combinedContactPoints, cp => cp.IsDefaultContactPoint);

			// Same for the duplicate practitioner
			foreach (var cp in _duplicatePractitioner.ContactPoints)
				combinedContactPoints.Add((ExternalPractitionerContactPointDetail)cp.Clone());

			// Store the deactivated contact point
			_deactivatedContactPointNotShown.Clear();
			_deactivatedContactPointNotShown.AddRange(CollectionUtils.Select(combinedContactPoints, cp => cp.Deactivated));

			// and only show the originally active contact points to user
			_table.Items.Clear();
			_table.Items.AddRange(CollectionUtils.Select(combinedContactPoints, cp => !cp.Deactivated));

			// There may be two default contact point, one from origial, one from duplicate
			// Make sure only one is checked as default
			_table.MakeDefaultContactPoint(originalDefaultContactPoint, true);
		}
	}
}