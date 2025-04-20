using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SISDatabaseProject.DAO
{
    public static class DatabaseManager
    {
        // Update this with your actual SQL Server connection string
        private static readonly string connectionString = @"Server=DESKTOP-HSTBEUL\SQLEXPRESS04;Database=SISDB;Trusted_Connection=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
