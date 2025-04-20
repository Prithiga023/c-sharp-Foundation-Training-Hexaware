using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CrimeReportingSystem.Util
{
    public static class DBConnUtil
    {
        private static SqlConnection? connection;

        public static SqlConnection GetConnection()
        {
            if (connection == null)
            {
                connection = new SqlConnection(GetConnectionString());
            }

            if (connection.State == ConnectionState.Closed || connection.State == ConnectionState.Broken)
            {
                connection.Open();
            }

            return connection;
        }

        private static string GetConnectionString()
        {
            string serverName = "DESKTOP-HSTBEUL\\SQLEXPRESS04";  
            string dbName = "Crimedb";                             

            return $"Server={serverName};Database={dbName};Integrated Security=True;Encrypt=False;TrustServerCertificate=True;";
        }
    }
}
