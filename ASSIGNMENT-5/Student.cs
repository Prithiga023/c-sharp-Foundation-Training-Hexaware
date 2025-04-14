using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonew
{
    public class Student
    {
        public int StudentId;
        public string FirstName;
        public string LastName;
        public DateTime Dob;
        public string Email;
        public string PhoneNumber;
        public List<Course> EnrolledCourses = new List<Course>();
        public List<Payment> Payments = new List<Payment>();

        public Student(int id, string firstName, string lastName, DateTime dob, string email, string phone)
        {
            StudentId = id;
            FirstName = firstName;
            LastName = lastName;
            Dob = dob;
            Email = email;
            PhoneNumber = phone;
        }

        public void EnrollInCourse(Course course)
        {
            if (!EnrolledCourses.Contains(course))
            {
                EnrolledCourses.Add(course);
                course.EnrolledStudents.Add(this);
            }
        }

        public void UpdateStudentInfo(string firstName, string lastName, DateTime dob, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Dob = dob;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public void MakePayment(decimal amount, DateTime paymentDate)
        {
            var payment = new Payment(Payments.Count + 1, this, amount, paymentDate);
            Payments.Add(payment);
        }

        public void DisplayStudentInfo()
        {
            Console.WriteLine($"ID: {StudentId}, Name: {FirstName} {LastName}, DOB: {Dob.ToShortDateString()}, Email: {Email}, Phone: {PhoneNumber}");
        }

        public List<Course> GetEnrolledCourses() => EnrolledCourses;
        public List<Payment> GetPaymentHistory() => Payments;
    }
}
