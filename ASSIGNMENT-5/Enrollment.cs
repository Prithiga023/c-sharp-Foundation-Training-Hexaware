using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonew
{
    public class Enrollment
    {
        public int EnrollmentId { get; }
        public Student Student { get; }
        public Course Course { get; }
        public DateTime EnrollmentDate { get; }

        public Enrollment(int enrollmentId, Student student, Course course, DateTime enrollmentDate)
        {
            if (student == null)
                throw new ArgumentNullException(nameof(student), "Student cannot be null.");
            if (course == null)
                throw new ArgumentNullException(nameof(course), "Course cannot be null.");
            if (enrollmentDate == null)
                throw new ArgumentNullException(nameof(enrollmentDate), "Enrollment date cannot be null.");

            EnrollmentId = enrollmentId;
            Student = student;
            Course = course;
            EnrollmentDate = enrollmentDate;
        }

        public void DisplayEnrollmentDetails()
        {
            Console.WriteLine($"Enrollment ID: {EnrollmentId}, Student: {Student.FirstName} {Student.LastName}, Course: {Course.CourseName}, Date: {EnrollmentDate.ToShortDateString()}");
        }
    }
}
