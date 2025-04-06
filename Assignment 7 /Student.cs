using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    public class Student
    {
        public string Name { get; set; }
        public List<Enrollment> Enrollments { get; set; }
        public List<Payment> Payments { get; set; }

        public Student(string name)
        {
            Name = name;
            Enrollments = new List<Enrollment>();
            Payments = new List<Payment>();
        }
    }
}
