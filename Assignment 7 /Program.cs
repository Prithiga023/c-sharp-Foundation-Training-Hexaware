using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    class Program
    {
        static void Main(string[] args)
        {
            SIS sis = new SIS();

            while (true)
            {
                Console.WriteLine("\n--- Student Information System ---");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Course");
                Console.WriteLine("3. Enroll Student");
                Console.WriteLine("4. Assign Course to Teacher");
                Console.WriteLine("5. Add Payment");
                Console.WriteLine("6. View Student Enrollments");
                Console.WriteLine("7. View Teacher Courses");
                Console.WriteLine("8. Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Student Name: ");
                        sis.AddStudent(Console.ReadLine());
                        break;

                    case "2":
                        Console.Write("Course Title: ");
                        sis.AddCourse(Console.ReadLine());
                        break;

                    case "3":
                        Console.Write("Student Name: ");
                        string sName = Console.ReadLine();
                        Console.Write("Course Title: ");
                        string cTitle = Console.ReadLine();
                        Console.Write("Enrollment Date (yyyy-mm-dd): ");
                        DateTime eDate = DateTime.Parse(Console.ReadLine());
                        sis.AddEnrollment(sName, cTitle, eDate);
                        break;

                    case "4":
                        Console.Write("Course Title: ");
                        string courseTitle = Console.ReadLine();
                        Console.Write("Teacher Name: ");
                        string teacherName = Console.ReadLine();
                        sis.AssignCourseToTeacher(courseTitle, teacherName);
                        break;

                    case "5":
                        Console.Write("Student Name: ");
                        string payStudent = Console.ReadLine();
                        Console.Write("Amount: ");
                        double amount = double.Parse(Console.ReadLine());
                        Console.Write("Payment Date (yyyy-mm-dd): ");
                        DateTime pDate = DateTime.Parse(Console.ReadLine());
                        sis.AddPayment(payStudent, amount, pDate);
                        break;

                    case "6":
                        Console.Write("Student Name: ");
                        sis.GetEnrollmentsForStudent(Console.ReadLine());
                        break;

                    case "7":
                        Console.Write("Teacher Name: ");
                        sis.GetCoursesForTeacher(Console.ReadLine());
                        break;

                    case "8":
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;

                }
            }
        }
    }
}
    
