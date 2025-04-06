using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    public class Teacher
    {

        public string Name { get; set; }
        public List<Course> AssignedCourses { get; set; }

        public Teacher(string name)
        {
            Name = name;
            AssignedCourses = new List<Course>();
        }
    }
}
