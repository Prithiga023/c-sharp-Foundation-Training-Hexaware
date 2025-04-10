using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Exception
{

    public class SISException : System.Exception
    {
        public SISException() : base() { }
        public SISException(string message) : base(message) { }
        public SISException(string message, System.Exception inner) : base(message, inner) { }
    }
}