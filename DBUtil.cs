using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Util
{
    public class DBUtil
    {
        private static string connectionString = "Data Source=DESKTOP-HSTBEUL\\SQLEXPRESS04;Initial Catalog=SISD;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static string GetConnectionString()
        {
            return connectionString;
        }
    }
}






