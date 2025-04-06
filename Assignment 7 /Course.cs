using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    public class Course
    {
        public string Title { get; set; }
        public List<Enrollment> Enrollments { get; set; }

        public Course(string title)
        {
            Title = title;
            Enrollments = new List<Enrollment>();
        }
    }
}
