using System;
using System.Collections.Generic;
using System.Text;
using ClearCanvas.Common;
using ClearCanvas.Enterprise.Hibernate;
using ClearCanvas.Healthcare.Brokers;
using ClearCanvas.Healthcare.Workflow.Registration;
using ClearCanvas.Enterprise.Hibernate.Hql;
using ClearCanvas.Enterprise;
using ClearCanvas.Common.Utilities;
using ClearCanvas.Enterprise.Core;

namespace ClearCanvas.Healthcare.Hibernate.Brokers
{
    [ExtensionOf(typeof(BrokerExtensionPoint))]
    public class RegistrationWorklistBroker : Broker, IRegistrationWorklistBroker
    {
        public IList<WorklistQueryResult> GetWorklist(SearchCriteria criteria, PatientProfileSearchCriteria profileCriteria)
        {
            if (criteria is ModalityProcedureStepSearchCriteria)
                return GetWorklistHelper(criteria as ModalityProcedureStepSearchCriteria, profileCriteria);
            else if (criteria is CheckInProcedureStepSearchCriteria)
                return GetWorklistHelper(criteria as CheckInProcedureStepSearchCriteria, profileCriteria);
            else
                throw new Exception("This SearchCriteria is not supported");            
        }

        private IList<WorklistQueryResult> GetWorklistHelper(ModalityProcedureStepSearchCriteria criteria, PatientProfileSearchCriteria profileCriteria)
        {
            HqlReportQuery query = new HqlReportQuery(new HqlFrom("sps", "ModalityProcedureStep"));

            query.Joins.Add(new HqlJoin("spst", "sps.Type"));
            query.Joins.Add(new HqlJoin("m", "sps.Modality"));
            query.Joins.Add(new HqlJoin("rp", "sps.RequestedProcedure"));
            query.Joins.Add(new HqlJoin("rpt", "rp.Type"));
            query.Joins.Add(new HqlJoin("o", "rp.Order"));
            query.Joins.Add(new HqlJoin("ds", "o.DiagnosticService"));
            query.Joins.Add(new HqlJoin("v", "o.Visit"));
            query.Joins.Add(new HqlJoin("p", "o.Patient"));
            query.Joins.Add(new HqlJoin("pp", "p.Profiles"));

            query.Selects.Add(new HqlSelect("p"));
            query.Selects.Add(new HqlSelect("pp"));
            query.Selects.Add(new HqlSelect("o"));
            query.Selects.Add(new HqlSelect("rp"));
            query.Selects.Add(new HqlSelect("sps"));
            query.Selects.Add(new HqlSelect("pp.Mrn"));
            query.Selects.Add(new HqlSelect("pp.Name"));
            query.Selects.Add(new HqlSelect("v.VisitNumber"));
            query.Selects.Add(new HqlSelect("o.AccessionNumber"));
            query.Selects.Add(new HqlSelect("ds.Name"));
            query.Selects.Add(new HqlSelect("rpt.Name"));
            query.Selects.Add(new HqlSelect("spst.Name"));
            query.Selects.Add(new HqlSelect("m.Name"));
            query.Selects.Add(new HqlSelect("o.Priority"));
            query.Selects.Add(new HqlSelect("sps.State"));

            query.Conditions.AddRange(HqlCondition.FromSearchCriteria("sps", criteria));

            //// add some criteria to filter the patient profiles
            //PatientProfileSearchCriteria profileCriteria = new PatientProfileSearchCriteria();
            //profileCriteria.Mrn.AssigningAuthority.EqualTo(patientProfileAuthority);
            if (profileCriteria != null)
                query.Conditions.AddRange(HqlCondition.FromSearchCriteria("pp", profileCriteria));

            List<WorklistQueryResult> results = new List<WorklistQueryResult>();
            foreach (object[] tuple in ExecuteHql(query))
            {
                results.Add((WorklistQueryResult)Activator.CreateInstance(typeof(WorklistQueryResult), tuple));
            }
            return results;
        }

        private IList<WorklistQueryResult> GetWorklistHelper(CheckInProcedureStepSearchCriteria criteria, PatientProfileSearchCriteria profileCriteria)
        {
            HqlReportQuery query = new HqlReportQuery(new HqlFrom("sps", "CheckInProcedureStep"));

            query.Joins.Add(new HqlJoin("rp", "sps.RequestedProcedure"));
            query.Joins.Add(new HqlJoin("rpt", "rp.Type"));
            query.Joins.Add(new HqlJoin("o", "rp.Order"));
            query.Joins.Add(new HqlJoin("ds", "o.DiagnosticService"));
            query.Joins.Add(new HqlJoin("v", "o.Visit"));
            query.Joins.Add(new HqlJoin("p", "o.Patient"));
            query.Joins.Add(new HqlJoin("pp", "p.Profiles"));

            query.Selects.Add(new HqlSelect("p"));
            query.Selects.Add(new HqlSelect("pp"));
            query.Selects.Add(new HqlSelect("o"));
            query.Selects.Add(new HqlSelect("rp"));
            query.Selects.Add(new HqlSelect("sps"));
            query.Selects.Add(new HqlSelect("pp.Mrn"));
            query.Selects.Add(new HqlSelect("pp.Name"));
            query.Selects.Add(new HqlSelect("v.VisitNumber"));
            query.Selects.Add(new HqlSelect("o.AccessionNumber"));
            query.Selects.Add(new HqlSelect("ds.Name"));
            query.Selects.Add(new HqlSelect("rpt.Name"));
            query.Selects.Add(new HqlSelect("o.Priority"));
            query.Selects.Add(new HqlSelect("sps.State"));

            query.Conditions.AddRange(HqlCondition.FromSearchCriteria("sps", criteria));

            //// add some criteria to filter the patient profiles
            //PatientProfileSearchCriteria profileCriteria = new PatientProfileSearchCriteria();
            //profileCriteria.Mrn.AssigningAuthority.EqualTo(patientProfileAuthority);
            if (profileCriteria != null)
                query.Conditions.AddRange(HqlCondition.FromSearchCriteria("pp", profileCriteria));

            List<WorklistQueryResult> results = new List<WorklistQueryResult>();
            foreach (object[] tuple in ExecuteHql(query))
            {
                results.Add((WorklistQueryResult)Activator.CreateInstance(typeof(WorklistQueryResult), tuple));
            }
            return results;
        }
    
    }
}
