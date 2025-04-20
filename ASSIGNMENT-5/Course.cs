using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonew
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        private Teacher courseTeacher;
        private List<Student> enrolledStudents = new List<Student>();

        public Course(int courseId, string courseName, string courseCode)
        {
            CourseId = courseId;
            CourseName = courseName;
            CourseCode = courseCode;
        }

        // Assign a teacher to the course
        public void AssignTeacher(Teacher teacher)
        {
            courseTeacher = teacher;
        }

        // Get the assigned teacher
        public Teacher GetTeacher()
        {
            return courseTeacher;
        }

        // Enroll a student in the course
        public void AddStudent(Student student)
        {
            if (!enrolledStudents.Contains(student))
            {
                enrolledStudents.Add(student);
            }
        }

        // Get a list of students enrolled in the course
        public List<Student> GetEnrollments()
        {
            return enrolledStudents;
        }
    }
}
