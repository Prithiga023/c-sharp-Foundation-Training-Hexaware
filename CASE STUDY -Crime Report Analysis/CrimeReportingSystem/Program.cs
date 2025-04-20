using CrimeReportingSystem.dao;
using CrimeReportingSystem.Entity;
using CrimeReportingSystem.exception;
using Microsoft.Data.SqlClient;
using System;

namespace CrimeReportingSystem
{
    class Program
    {
        static string connectionString = @"Data Source=DESKTOP-HSTBEUL\SQLEXPRESS04;Initial Catalog=CrimeDB;Integrated Security=True;TrustServerCertificate=True";

        // Ensure there is only one Main method in the application
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n========= Crime Analysis and Reporting System =========");
                Console.WriteLine("1. Create Incident");
                Console.WriteLine("2. Update Incident Status");
                Console.WriteLine("3. Search Incidents by Type");
                Console.WriteLine("4. View Incidents in Date Range");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateIncident();
                        break;
                    case "2":
                        UpdateIncidentStatus();
                        break;
                    case "3":
                        SearchIncidentByType();
                        break;
                    case "4":
                        ViewIncidentsInDateRange();
                        break;
                    case "5":
                        Console.WriteLine("Exiting. Thank you!");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void CreateIncident()
        {
            try
            {
                Console.Write("Incident Type: ");
                string type = Console.ReadLine();

                Console.Write("Incident Date (yyyy-mm-dd): ");
                string dateInput = Console.ReadLine();
                DateTime date = DateTime.Parse(dateInput);

                Console.Write("Location: ");
                string location = Console.ReadLine();

                Console.Write("Description: ");
                string description = Console.ReadLine();

                Console.Write("Status: ");
                string status = Console.ReadLine();

                Console.Write("Victim ID: ");
                int victimId = int.Parse(Console.ReadLine());

                Console.Write("Suspect ID: ");
                int suspectId = int.Parse(Console.ReadLine());

                Console.Write("Agency ID: ");
                int agencyId = int.Parse(Console.ReadLine());

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"INSERT INTO Incident (IncidentType, IncidentDate, Location, Description, Status, VictimID, SuspectID, AgencyID)
                                     VALUES (@Type, @Date, @Location, @Description, @Status, @VictimID, @SuspectID, @AgencyID)";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Type", type);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Location", location);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Status", status);
                    cmd.Parameters.AddWithValue("@VictimID", victimId);
                    cmd.Parameters.AddWithValue("@SuspectID", suspectId);
                    cmd.Parameters.AddWithValue("@AgencyID", agencyId);

                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine(rows > 0 ? "Incident recorded successfully." : "Failed to record the incident.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while creating incident: " + ex.Message);
            }
        }

        static void UpdateIncidentStatus()
        {
            try
            {
                Console.Write("Incident ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("New Status: ");
                string newStatus = Console.ReadLine();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE Incident SET Status = @Status WHERE IncidentID = @ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Status", newStatus);
                    cmd.Parameters.AddWithValue("@ID", id);

                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine(rows > 0 ? "Incident status updated." : "Incident not found.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while updating status: " + ex.Message);
            }
        }

        static void SearchIncidentByType()
        {
            try
            {
                Console.Write("Incident Type: ");
                string type = Console.ReadLine();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Incident WHERE IncidentType = @Type";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Type", type);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Console.WriteLine("\n--- Incidents Found ---");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["IncidentID"]}, Date: {reader["IncidentDate"]}, Location: {reader["Location"]}, Status: {reader["Status"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No incidents found for the given type.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while searching: " + ex.Message);
            }
        }

        static void ViewIncidentsInDateRange()
        {
            try
            {
                Console.Write("From Incident Date (yyyy-mm-dd): ");
                string fromDateInput = Console.ReadLine();
                DateTime fromDate = DateTime.Parse(fromDateInput);

                Console.Write("To Incident Date (yyyy-mm-dd): ");
                string toDateInput = Console.ReadLine();
                DateTime toDate = DateTime.Parse(toDateInput);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Incident WHERE IncidentDate BETWEEN @StartDate AND @EndDate";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@StartDate", fromDate);
                    cmd.Parameters.AddWithValue("@EndDate", toDate);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        Console.WriteLine("\n--- Incidents Found ---");
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["IncidentID"]}, Type: {reader["IncidentType"]}, Date: {reader["IncidentDate"]}, Location: {reader["Location"]}, Status: {reader["Status"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No incidents found in the given date range.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while fetching data: " + ex.Message);
            }
        }
    }
}
