using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    public class SISException : Exception
    {
        public SISException(string message) : base(message)
        {
        }

    }
}
