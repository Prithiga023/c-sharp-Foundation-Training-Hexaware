using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonew
{
    public class Enrollment
    {
        public int EnrollmentId;
        public Student Student;
        public Course Course;
        public DateTime EnrollmentDate;

        public Enrollment(int id, Student student, Course course, DateTime date)
        {
            EnrollmentId = id;
            Student = student;
            Course = course;
            EnrollmentDate = date;
        }

        public Student GetStudent() => Student;
        public Course GetCourse() => Course;
    }
}

