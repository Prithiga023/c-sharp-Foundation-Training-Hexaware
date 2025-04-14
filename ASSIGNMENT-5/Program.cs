using NUnit.Framework;

namespace demonew
{
    public class Program
    {
        // Student Class
        static void Main()
        {
            SIS system = new SIS();

            Teacher teacher = new Teacher(1, "John", "Doe", "john@example.com");
            system.Teachers.Add(teacher);

            Course math = new Course(101, "Mathematics", "MTH101");
            system.Courses.Add(math);
            system.AssignTeacherToCourse(teacher, math);

            Student student1 = new Student(1, "Alice", "Smith", new DateTime(2001, 5, 21), "alice@example.com", "9876543210");
            system.Students.Add(student1);

            system.EnrollStudentInCourse(student1, math);
            system.RecordPayment(student1, 500, DateTime.Now);

            student1.DisplayStudentInfo();
            system.GenerateEnrollmentReport(math);
            system.GeneratePaymentReport(student1);
            system.CalculateCourseStatistics(math);
        }
    }
}
