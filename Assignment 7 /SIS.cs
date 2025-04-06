using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    public class SIS
    {
        private List<Student> students = new List<Student>();
        private List<Course> courses = new List<Course>();
        private List<Teacher> teachers = new List<Teacher>();

        public void AddStudent(string name)
        {
            students.Add(new Student(name));
            Console.WriteLine("Student added.");
        }

        public void AddCourse(string title)
        {
            courses.Add(new Course(title));
            Console.WriteLine("Course added.");
        }

        public void AddEnrollment(string studentName, string courseTitle, DateTime date)
        {
            var student = students.FirstOrDefault(s => s.Name == studentName);
            var course = courses.FirstOrDefault(c => c.Title == courseTitle);

            if (student != null && course != null)
            {
                var enrollment = new Enrollment(student, course, date);
                student.Enrollments.Add(enrollment);
                course.Enrollments.Add(enrollment);
                Console.WriteLine("Enrollment added.");
            }
            else
            {
                Console.WriteLine("Student or Course not found.");
            }
        }

        public void AssignCourseToTeacher(string courseTitle, string teacherName)
        {
            var teacher = teachers.FirstOrDefault(t => t.Name == teacherName);
            var course = courses.FirstOrDefault(c => c.Title == courseTitle);

            if (course != null)
            {
                if (teacher == null)
                {
                    teacher = new Teacher(teacherName);
                    teachers.Add(teacher);
                }

                teacher.AssignedCourses.Add(course);
                Console.WriteLine("Course assigned to teacher.");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }

        public void AddPayment(string studentName, double amount, DateTime date)
        {
            var student = students.FirstOrDefault(s => s.Name == studentName);

            if (student != null)
            {
                var payment = new Payment(student, amount, date);
                student.Payments.Add(payment);
                Console.WriteLine("Payment added.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }

        public void GetEnrollmentsForStudent(string studentName)
        {
            var student = students.FirstOrDefault(s => s.Name == studentName);

            if (student != null && student.Enrollments.Count > 0)
            {
                Console.WriteLine($"Enrollments for {studentName}:");
                foreach (var e in student.Enrollments)
                {
                    Console.WriteLine($"- {e.Course.Title} on {e.EnrollmentDate.ToShortDateString()}");
                }
            }
            else
            {
                Console.WriteLine("No enrollments found.");
            }
        }

        public void GetCoursesForTeacher(string teacherName)
        {
            var teacher = teachers.FirstOrDefault(t => t.Name == teacherName);

            if (teacher != null && teacher.AssignedCourses.Count > 0)
            {
                Console.WriteLine($"Courses for {teacherName}:");
                foreach (var c in teacher.AssignedCourses)
                {
                    Console.WriteLine($"- {c.Title}");
                }
            }
            else
            {
                Console.WriteLine("No courses assigned.");
            }
        }
    }
}
