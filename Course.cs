using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Entity
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }

        public Course(int courseId, string courseName, int credits)
        {
            CourseId = courseId;
            CourseName = courseName;
            Credits = credits;
        }
    }
}
