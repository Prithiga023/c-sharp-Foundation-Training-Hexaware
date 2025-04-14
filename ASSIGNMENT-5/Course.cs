using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonew
{
    public class Course
    {
        public int CourseId;
        public string Name;
        public string Code;
        public Teacher Instructor;
        public List<Student> EnrolledStudents = new List<Student>();

        public Course(int id, string name, string code)
        {
            CourseId = id;
            Name = name;
            Code = code;
        }

        public void AssignTeacher(Teacher teacher)
        {
            Instructor = teacher;
            teacher.AssignedCourses.Add(this);
        }

        public void UpdateCourseInfo(string code, string name, string instructorName)
        {
            Code = code;
            Name = name;
        }

        public void DisplayCourseInfo()
        {
            Console.WriteLine($"ID: {CourseId}, Name: {Name}, Code: {Code}, Instructor: {Instructor?.FirstName} {Instructor?.LastName}");
        }

        public List<Student> GetEnrollments() => EnrolledStudents;
        public Teacher GetTeacher() => Instructor;
    }
}


