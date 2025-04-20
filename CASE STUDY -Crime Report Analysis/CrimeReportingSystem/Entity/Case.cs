using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeReportingSystem.Entity
{
    public class Case
    {
        public int CaseID { get; set; }
        public string CaseDescription { get; set; }
        public List<int> IncidentIDs { get; set; } // Association with multiple incidents
        public object Description { get; internal set; }

        public Case()
        {
            IncidentIDs = new List<int>();
        }

        public Case(int caseID, string caseDescription, List<int> incidentIDs)
        {
            CaseID = caseID;
            CaseDescription = caseDescription;
            IncidentIDs = incidentIDs;
        }
    }
}
