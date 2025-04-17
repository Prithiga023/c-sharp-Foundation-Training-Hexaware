using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


    namespace OrderManagementSystem.util
    {
        public class DBConnUtil
        {
            private static readonly string connectionString =
                "Data Source=DESKTOP-HSTBEUL\\SQLEXPRESS04;Initial Catalog=OrderManagementDB;Integrated Security=True";

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(connectionString);
            }
        }
    }
