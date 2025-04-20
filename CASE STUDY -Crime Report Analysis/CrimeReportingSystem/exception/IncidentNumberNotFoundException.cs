using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrimeReportingSystem.exception
{
    public class IncidentNumberNotFoundException : Exception
    {
        public IncidentNumberNotFoundException() : base("Incident number not found in the database.") { }
        public IncidentNumberNotFoundException(string message) : base(message) { }
    }
}
