﻿using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Hibernate.Hql;

namespace ClearCanvas.Healthcare.Hibernate.Brokers.QueryBuilders
{
	/// <summary>
	/// Specialization of <see cref="WorklistItemQueryBuilder"/> for protocol worklists.
	/// </summary>
	public class ProtocolWorklistItemQueryBuilder : WorklistItemQueryBuilder
	{
		private static readonly HqlCondition ConditionMostRecentProtocolAssignmentStepIfRejected = new HqlCondition(
			"((pr.Status not in (?)) or (ps.EndTime = (select max(ps2.EndTime) from ProcedureStep ps2 where ps.Protocol = ps2.Protocol)))", ProtocolStatus.RJ);

		public override void AddRootQuery(HqlProjectionQuery query, QueryBuilderArgs args)
		{
			base.AddRootQuery(query, args);

			var from = query.Froms[0];	// this would be added by the base.AddWorklistRootQuery call

			// join protocol object, because may have criteria on this object
			from.Joins.Add(HqlConstants.JoinProtocol);

			// check if we need to apply the "most recent step" condition
			// this is essentially a workaround to avoid showing duplicates in some worklist results
			// we can only apply this workaround when there is exactly one ps class specified
			// fortunately, there are no use cases yet where more than one ps class is specified
			// that require the workaround
			if (args.ProcedureStepClasses.Length == 1)
			{
				var psClass = CollectionUtils.FirstElement(args.ProcedureStepClasses);
				// the proc step class may be set to the more general "ProtocolProcedureStep" so
				// we need to check for both
				if (psClass == typeof(ProtocolAssignmentStep) || psClass == typeof(ProtocolProcedureStep))
				{
					// when querying for Rejected protocols, only show the most recent ProtocolAssignmentStep, as there may be many of them
					query.Conditions.Add(ConditionMostRecentProtocolAssignmentStepIfRejected);
				}
			}
		}
	}
}
