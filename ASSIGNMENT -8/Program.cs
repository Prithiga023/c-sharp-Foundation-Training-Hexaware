using SISDatabaseProject.DAO;
using SISDatabaseProject.Entity;
using SISDatabaseProject.Service;
using System;
using System.Linq;

namespace SISDatabaseProject
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n==== STUDENT INFORMATION SYSTEM ====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Course");
                Console.WriteLine("3. Add Teacher");
                Console.WriteLine("4. Enroll Student");
                Console.WriteLine("5. Record Payment");
                Console.WriteLine("6. Search Students");
                Console.WriteLine("7. Search Courses");
                Console.WriteLine("8. Search Payments");
                Console.WriteLine("9. Exit");
                Console.Write("Choose an option: ");
                var input = Console.ReadLine();

                try
                {
                    switch (input)
                    {
                        case "1":
                            AddStudent();
                            break;
                        case "2":
                            AddCourse();
                            break;
                        case "3":
                            AddTeacher();
                            break;
                        case "4":
                            EnrollStudent();
                            break;
                        case "5":
                            RecordPayment();
                            break;
                        case "6":
                            SearchStudents();
                            break;
                        case "7":
                            SearchCourses();
                            break;
                        case "8":
                            SearchPayments();
                            break;
                        case "9":
                            running = false;
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void AddStudent()
        {
            var dao = new StudentDAO();
            Console.Write("First Name: ");
            string first = Console.ReadLine();
            Console.Write("Last Name: ");
            string last = Console.ReadLine();
            Console.Write("DOB (yyyy-MM-dd): ");
            DateTime dob = DateTime.Parse(Console.ReadLine());
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Phone: ");
            string phone = Console.ReadLine();

            dao.AddStudent(new Student
            {
                FirstName = first,
                LastName = last,
                DateOfBirth = dob,
                Email = email,
                PhoneNumber = phone,
                OutstandingBalance = 0
            });

            Console.WriteLine("Student added.");
        }

        static void AddCourse()
        {
            var dao = new CourseDAO();
            Console.Write("Course Name: ");
            string name = Console.ReadLine();
            Console.Write("Course Code: ");
            string code = Console.ReadLine();
            Console.Write("Teacher ID (optional): ");
            string input = Console.ReadLine();
            int? teacherId = string.IsNullOrEmpty(input) ? null : int.Parse(input);

            dao.AddCourse(new Course
            {
                CourseName = name,
                CourseCode = code,
                TeacherId = teacherId
            });

            Console.WriteLine("Course added.");
        }

        static void AddTeacher()
        {
            var dao = new TeacherDAO();
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Expertise: ");
            string expertise = Console.ReadLine();

            dao.AddTeacher(new Teacher
            {
                Name = name,
                Email = email,
                Expertise = expertise
            });

            Console.WriteLine("Teacher added.");
        }

        static void EnrollStudent()
        {
            var dao = new EnrollmentDAO();
            Console.Write("Student ID: ");
            int studentId = int.Parse(Console.ReadLine());
            Console.Write("Course ID: ");
            int courseId = int.Parse(Console.ReadLine());

            dao.EnrollStudent(new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = DateTime.Now
            });

            Console.WriteLine("Enrollment successful.");
        }

        static void RecordPayment()
        {
            var dao = new PaymentDAO();
            Console.Write("Student ID: ");
            int studentId = int.Parse(Console.ReadLine());
            Console.Write("Amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            dao.RecordPayment(new Payment
            {
                StudentId = studentId,
                PaymentAmount = amount,
                PaymentDate = DateTime.Now
            });

            Console.WriteLine("Payment recorded.");
        }

        static void SearchStudents()
        {
            Console.Write("Search by name (optional): ");
            string name = Console.ReadLine();
            Console.Write("Search by email (optional): ");
            string email = Console.ReadLine();
            Console.Write("Search by phone (optional): ");
            string phone = Console.ReadLine();

            var result = DynamicQueryBuilder.SearchStudents(name, email, phone);

            if (result.Rows.Count > 0)
            {
                Console.WriteLine("Results:");
                foreach (System.Data.DataRow row in result.Rows)
                {
                    Console.WriteLine($"ID: {row["StudentId"]} | Name: {row["FirstName"]} {row["LastName"]} | Email: {row["Email"]}");
                }
            }
            else
            {
                Console.WriteLine("No students found matching your search.");
            }
        }

        static void SearchCourses()
        {
            Console.Write("Course Name (optional): ");
            string name = Console.ReadLine();
            Console.Write("Course Code (optional): ");
            string code = Console.ReadLine();

            var result = DynamicQueryBuilder.SearchCourses(name, code);

            if (result.Rows.Count > 0)
            {
                Console.WriteLine("Results:");
                foreach (System.Data.DataRow row in result.Rows)
                {
                    Console.WriteLine($"ID: {row["CourseId"]} | Name: {row["CourseName"]} | Code: {row["CourseCode"]}");
                }
            }
            else
            {
                Console.WriteLine("No courses found matching your search.");
            }
        }

        static void SearchPayments()
        {
            Console.Write("Student ID (optional): ");
            string sid = Console.ReadLine();
            int? studentId = string.IsNullOrEmpty(sid) ? null : int.Parse(sid);

            Console.Write("From Date (yyyy-MM-dd, optional): ");
            string from = Console.ReadLine();
            DateTime? fromDate = string.IsNullOrEmpty(from) ? null : DateTime.Parse(from);

            Console.Write("To Date (yyyy-MM-dd, optional): ");
            string to = Console.ReadLine();
            DateTime? toDate = string.IsNullOrEmpty(to) ? null : DateTime.Parse(to);

            var result = DynamicQueryBuilder.SearchPayments(studentId, fromDate, toDate);

            if (result.Rows.Count > 0)
            {
                Console.WriteLine("Results:");
                foreach (System.Data.DataRow row in result.Rows)
                {
                    Console.WriteLine($"Payment ID: {row["PaymentId"]} | Student ID: {row["StudentId"]} | Amount: ₹{row["PaymentAmount"]} | Date: {row["PaymentDate"]}");
                }
            }
            else
            {
                Console.WriteLine("No payments found matching your search.");
            }
        }
    }
}
