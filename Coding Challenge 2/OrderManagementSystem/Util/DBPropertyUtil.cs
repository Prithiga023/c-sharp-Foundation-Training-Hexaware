using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace OrderManagementSystem.util
{
    public class DBPropertyUtil
    {
        public static string GetConnectionString(string propertyName)
        {
            return ConfigurationManager.AppSettings[propertyName];
        }
    }
}
