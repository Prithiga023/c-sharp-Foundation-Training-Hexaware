using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeReportingSystem.Entity
{
    public class Report
    {
        public int ReportID { get; set; }
        public int IncidentID { get; set; }
        public int ReportingOfficerID { get; set; }
        public DateTime ReportDate { get; set; }
        public string ReportDetails { get; set; }
        public string Status { get; set; }

        public Report() { }

        public Report(int reportID, int incidentID, int reportingOfficerID, DateTime reportDate, string reportDetails, string status)
        {
            ReportID = reportID;
            IncidentID = incidentID;
            ReportingOfficerID = reportingOfficerID;
            ReportDate = reportDate;
            ReportDetails = reportDetails;
            Status = status;
        }
    }
}
