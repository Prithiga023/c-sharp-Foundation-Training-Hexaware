using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrimeReportingSystem.Entity;

namespace CrimeReportingSystem.dao
{
    public interface ICrimeAnalysisService
    {
        bool CreateIncident(Incident incident);
        bool UpdateIncidentStatus(int incidentId, string newStatus);
        List<Incident> GetIncidentsInDateRange(DateTime startDate, DateTime endDate);
        List<Incident> SearchIncidents(string incidentType);
        Report GenerateIncidentReport(Incident incident);
        Case CreateCase(string caseDescription, List<Incident> incidents);
        Case GetCaseDetails(int caseId);
        bool UpdateCaseDetails(Case caseDetails);
        List<Case> GetAllCases();
    }
}
