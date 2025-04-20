using System;
using System.Collections.Generic;
using System.Data;
using CrimeReportingSystem.Entity;
using CrimeReportingSystem.Util;
using Microsoft.Data.SqlClient;

namespace CrimeReportingSystem.dao
{
    public class CrimeAnalysisServiceImpl : ICrimeAnalysisService
    {
        private readonly SqlConnection connection;

        public CrimeAnalysisServiceImpl()
        {
            connection = DBConnUtil.GetConnection();
        }

        public bool CreateIncident(Incident incident)
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO Incidents (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID, AgencyID) " +
                               "VALUES (@type, @date, @loc, @desc, @status, @vic, @sus, @agency)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@type", incident.IncidentType);
                cmd.Parameters.AddWithValue("@date", incident.IncidentDate);
                cmd.Parameters.AddWithValue("@loc", incident.Location);
                cmd.Parameters.AddWithValue("@desc", incident.Description);
                cmd.Parameters.AddWithValue("@status", incident.Status);
                cmd.Parameters.AddWithValue("@vic", incident.VictimID);
                cmd.Parameters.AddWithValue("@sus", incident.SuspectID);
                cmd.Parameters.AddWithValue("@agency", incident.AgencyID);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in CreateIncident: " + ex.Message);  // Logging the exception for now
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public bool UpdateIncidentStatus(int incidentId, string newStatus)
        {
            try
            {
                connection.Open();
                string query = "UPDATE Incidents SET Status = @status WHERE IncidentID = @id";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@status", newStatus);
                cmd.Parameters.AddWithValue("@id", incidentId);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateIncidentStatus: " + ex.Message);  // Logging the exception for now
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Incident> GetIncidentsInDateRange(DateTime startDate, DateTime endDate)
        {
            List<Incident> incidents = new List<Incident>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM Incidents WHERE IncidentDate BETWEEN @start AND @end";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@start", startDate);
                cmd.Parameters.AddWithValue("@end", endDate);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        incidents.Add(new Incident(
                            (int)reader["IncidentID"],
                            reader["IncidentType"].ToString(),
                            (DateTime)reader["IncidentDate"],
                            reader["Location"].ToString(),
                            reader["Description"].ToString(),
                            reader["Status"].ToString(),
                            (int)reader["VictimID"],
                            (int)reader["SuspectID"],
                            (int)reader["AgencyID"]
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetIncidentsInDateRange: " + ex.Message);  // Logging the exception for now
            }
            finally
            {
                connection.Close();
            }
            return incidents;
        }

        public List<Incident> SearchIncidents(string incidentType)
        {
            List<Incident> incidents = new List<Incident>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM Incidents WHERE IncidentType = @type";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@type", incidentType);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        incidents.Add(new Incident(
                            (int)reader["IncidentID"],
                            reader["IncidentType"].ToString(),
                            (DateTime)reader["IncidentDate"],
                            reader["Location"].ToString(),
                            reader["Description"].ToString(),
                            reader["Status"].ToString(),
                            (int)reader["VictimID"],
                            (int)reader["SuspectID"],
                            (int)reader["AgencyID"]
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in SearchIncidents: " + ex.Message);  // Logging the exception for now
            }
            finally
            {
                connection.Close();
            }
            return incidents;
        }

        public Report GenerateIncidentReport(Incident incident)
        {
            return new Report(0, incident.IncidentID, 0, DateTime.Now, "Report auto-generated for incident: " + incident.IncidentID, "Draft");
        }

        public Case CreateCase(string caseDescription, List<Incident> incidents)
        {
            return new Case(0, caseDescription, incidents.ConvertAll(i => i.IncidentID));
        }

        public Case GetCaseDetails(int caseId)
        {
            return new Case(caseId, "Dummy Case", new List<int>()); // placeholder
        }

        public bool UpdateCaseDetails(Case caseDetails)
        {
            try
            {
                connection.Open();
                string query = "UPDATE Cases SET CaseDescription = @description WHERE CaseID = @caseId";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@description", caseDetails.Description);
                cmd.Parameters.AddWithValue("@caseId", caseDetails.CaseID);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in UpdateCaseDetails: " + ex.Message);  // Logging the exception for now
                return false;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Case> GetAllCases()
        {
            List<Case> cases = new List<Case>();
            try
            {
                connection.Open();
                string query = "SELECT * FROM Cases";
                SqlCommand cmd = new SqlCommand(query, connection);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        cases.Add(new Case(
                            (int)reader["CaseID"],
                            reader["CaseDescription"].ToString(),
                            new List<int>() // Placeholder for incident IDs
                        ));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in GetAllCases: " + ex.Message);  // Logging the exception for now
            }
            finally
            {
                connection.Close();
            }
            return cases;
        }
    }
}
