#region License

// Copyright (c) 2011, ClearCanvas Inc.
// All rights reserved.
// http://www.clearcanvas.ca
//
// This software is licensed under the Open Software License v3.0.
// For the complete license, see http://www.clearcanvas.ca/OSLv3.0

#endregion

using System;
using System.Security.Principal;
using System.Threading;

namespace ClearCanvas.Dicom.Audit
{
	/// <summary>
	/// Represents the source of a particular auditable event.
	/// </summary>
	public abstract class EventSource
	{
		/// <summary>
		/// The source of the auditable event is the current end user.
		/// </summary>
		public static readonly EventSource CurrentUser = new CurrentUserEventSource();

		/// <summary>
		/// A generic source for when the actual source is unknown.
		/// </summary>
		public static readonly EventSource UnknownSource = new OtherEventSource("Unknown");

		/// <summary>
		/// Gets a generic event source for other sources of auditable events.
		/// </summary>
		/// <param name="otherSourceName">The name of the source.</param>
		public static EventSource GetOtherEventSource(string otherSourceName)
		{
			return new OtherEventSource(otherSourceName);
		}

		/// <summary>
		/// Gets a user event source when the specified user is the source of the auditable event.
		/// </summary>
		/// <param name="userName">The username of the source.</param>
		public static EventSource GetUserEventSource(string userName)
		{
			return new UserEventSource(userName);
		}

		/// <summary>
		/// Gets the <paramref name="eventSource"/> as a <see cref="DicomAuditSource"/>.
		/// </summary>
		public static implicit operator DicomAuditSource(EventSource eventSource)
		{
			return eventSource.AsDicomAuditSource();
		}

		/// <summary>
		/// Gets the <paramref name="eventSource"/> as an <see cref="AuditActiveParticipant"/>.
		/// </summary>
		public static implicit operator AuditActiveParticipant(EventSource eventSource)
		{
			return eventSource.AsAuditActiveParticipant();
		}

		/// <summary>
		/// Gets the <paramref name="eventSource"/> as an <see cref="AuditProcessActiveParticipant"/> if supported.
		/// </summary>
		public static implicit operator AuditProcessActiveParticipant(EventSource eventSource)
		{
			var result = eventSource.AsAuditActiveParticipant() as AuditProcessActiveParticipant;
			if (result == null)
				throw new InvalidCastException();
			return result;
		}

		protected abstract DicomAuditSource AsDicomAuditSource();
		protected abstract AuditActiveParticipant AsAuditActiveParticipant();

		private class OtherEventSource : EventSource
		{
			private readonly string _id;

			public OtherEventSource(string id)
			{
				_id = id;
			}

			protected override DicomAuditSource AsDicomAuditSource()
			{
				return new DicomAuditSource(_id, string.Empty, AuditSourceTypeCodeEnum.ExternalSourceOtherOrUnknownType);
			}

			protected override AuditActiveParticipant AsAuditActiveParticipant()
			{
				return new AuditProcessActiveParticipant(_id);
			}
		}

		private class CurrentUserEventSource : EventSource
		{
			private static DicomAuditSource _currentUserAuditSource;
			private static AuditActiveParticipant _currentUserActiveParticipant;

			protected override DicomAuditSource AsDicomAuditSource()
			{
				return _currentUserAuditSource ??
				       (_currentUserAuditSource =
				        new DicomAuditSource(GetUserName(), string.Empty, AuditSourceTypeCodeEnum.EndUserInterface));
			}

			protected override AuditActiveParticipant AsAuditActiveParticipant()
			{
				return _currentUserActiveParticipant ??
				       (_currentUserActiveParticipant =
				        new AuditPersonActiveParticipant(GetUserName(), string.Empty, GetUserName()));
			}

			private static string GetUserName()
			{
				IPrincipal p = Thread.CurrentPrincipal;
				if (p == null || p.Identity == null || string.IsNullOrEmpty(p.Identity.Name))
					return string.Format("{0}@{1}", Environment.UserName, Environment.UserDomainName);
				return p.Identity.Name;
			}
		}

		private class UserEventSource : EventSource
		{
			private DicomAuditSource _currentUserAuditSource;
			private AuditActiveParticipant _currentUserActiveParticipant;
			private readonly string _username;

			internal UserEventSource(string name)
			{
				_username = name;
			}

			protected override DicomAuditSource AsDicomAuditSource()
			{
				return _currentUserAuditSource ??
				       (_currentUserAuditSource =
				        new DicomAuditSource(_username, string.Empty, AuditSourceTypeCodeEnum.EndUserInterface));
			}

			protected override AuditActiveParticipant AsAuditActiveParticipant()
			{
				return _currentUserActiveParticipant ??
				       (_currentUserActiveParticipant =
				        new AuditPersonActiveParticipant(_username, string.Empty, _username));
			}
		}
	}
}