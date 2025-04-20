using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SISDatabaseProject.DAO;
using SISDatabaseProject.Entity;

namespace SISDatabaseProject.Service
{
    public class TransactionService
    {
        private readonly StudentDAO studentDAO = new();
        private readonly TeacherDAO teacherDAO = new();
        private readonly CourseDAO courseDAO = new();
        private readonly EnrollmentDAO enrollmentDAO = new();
        private readonly PaymentDAO paymentDAO = new();

        public void RegisterStudent(Student student)
        {
            studentDAO.AddStudent(student);
            Console.WriteLine("Student registered successfully.");
        }

        public void AddTeacher(Teacher teacher)
        {
            teacherDAO.AddTeacher(teacher);
            Console.WriteLine(" Teacher added successfully.");
        }

        public void AddCourse(Course course)
        {
            courseDAO.AddCourse(course);
            Console.WriteLine(" Course added successfully.");
        }

        public void EnrollStudent(int studentId, int courseId)
        {
            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = DateTime.Today
            };
            enrollmentDAO.EnrollStudent(enrollment);
            Console.WriteLine(" Student enrolled in course.");
        }

        public void RecordPayment(int studentId, decimal amount)
        {
            var payment = new Payment
            {
                StudentId = studentId,
                PaymentAmount = amount,
                PaymentDate = DateTime.Today
            };
            paymentDAO.RecordPayment(payment);
            Console.WriteLine("Payment recorded.");
        }
    }
}
