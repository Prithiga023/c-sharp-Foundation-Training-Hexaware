using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Entity
{
    public class Clothing : Product
    {
        public string Size { get; set; }
        public string Color { get; set; }
    }
}
