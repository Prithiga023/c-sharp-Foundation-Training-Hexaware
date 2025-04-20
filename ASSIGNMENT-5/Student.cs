using System;
using System.Collections.Generic;

namespace demonew
{
    public class Student
    {
        public int StudentId { get; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        private List<Course> enrolledCourses = new List<Course>();
        private List<Payment> paymentHistory = new List<Payment>();

        public Student(int studentId, string firstName, string lastName, DateTime dob, string email, string phone)
        {
            ValidateStudentData(firstName, lastName, email);
            StudentId = studentId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        // Enroll the student in a course
        public void EnrollInCourse(Course course)
        {
            if (!enrolledCourses.Contains(course))
            {
                enrolledCourses.Add(course);
                course.AddStudent(this);
            }
        }

        // Get all the courses the student is enrolled in
        public List<Course> GetEnrollments()
        {
            return enrolledCourses;
        }

        // Make a payment for the student
        public void MakePayment(decimal amount, DateTime paymentDate)
        {
            paymentHistory.Add(new Payment(this, amount, paymentDate));
        }

        // Get the student's payment history
        public List<Payment> GetPaymentHistory()
        {
            return paymentHistory;
        }

        // Update student information
        public void UpdateStudentInfo(string firstName, string lastName, string email)
        {
            ValidateStudentData(firstName, lastName, email);
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        // Validation for student data
        private void ValidateStudentData(string firstName, string lastName, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Invalid student name.");
            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Invalid email format.");
        }
    }
}
