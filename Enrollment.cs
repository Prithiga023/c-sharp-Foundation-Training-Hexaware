using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Entity
{
    public class Enrollment
    {
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public string EnrollmentDate { get; set; }

        public Enrollment(int studentId, int courseId, int teacherId, string enrollmentDate)
        {
            StudentId = studentId;
            CourseId = courseId;
            TeacherId = teacherId;
            EnrollmentDate = enrollmentDate;
        }
    }
}
