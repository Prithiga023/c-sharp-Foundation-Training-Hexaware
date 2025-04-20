using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeReportingSystem.Util
{
    public static class ConfigHelper  // Define a class to contain the method
    {
        public static Dictionary<string, string> GetProperties(string fileName)
        {
            var properties = new Dictionary<string, string>();

            try
            {
                if (!File.Exists(fileName))
                {
                    throw new FileNotFoundException($"The configuration file '{fileName}' was not found.");
                }

                // Read all lines from the file
                foreach (var line in File.ReadAllLines(fileName))
                {
                    if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                    {
                        var parts = line.Split('=');
                        if (parts.Length == 2)
                        {
                            // Add the property to the dictionary
                            properties[parts[0].Trim()] = parts[1].Trim();
                        }
                    }
                }

                return properties;
            }
            catch (Exception ex)
            {
                // Print error message and rethrow the exception
                Console.WriteLine("Error loading DB properties: " + ex.Message);
                throw;
            }
        }
    }
}
