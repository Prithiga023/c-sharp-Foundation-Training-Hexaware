using NUnit.Framework;

namespace demonew
{
    class Program
    {
        static void Main(string[] args)
        {
            SIS sis = new SIS(); // This will load existing data from the file
            sis.LoadData(); // Assuming LoadData method exists to populate the SIS object

            Console.WriteLine("Enter student ID:");
            int studentId = Convert.ToInt32(Console.ReadLine());

            // Check if the student already exists
            var existingStudent = sis.Students.FirstOrDefault(s => s.StudentId == studentId);
            if (existingStudent != null)
            {
                Console.WriteLine("Student found. Do you want to update their information? (yes/no)");
                string updateChoice = Console.ReadLine()?.ToLower();
                if (updateChoice == "yes")
                {
                    Console.WriteLine("Enter first name:");
                    string firstName = Console.ReadLine();

                    Console.WriteLine("Enter last name:");
                    string lastName = Console.ReadLine();

                    Console.WriteLine("Enter email:");
                    string email = Console.ReadLine();

                    // Update student info
                    existingStudent.UpdateStudentInfo(firstName, lastName, email);
                    Console.WriteLine("Student information updated successfully.");
                }
                else
                {
                    Console.WriteLine("No changes made.");
                }
            }
            else
            {
                // If student is not found, allow adding new student
                Console.WriteLine("Student not found. Adding a new student...");

                Console.WriteLine("Enter first name:");
                string firstName = Console.ReadLine();

                Console.WriteLine("Enter last name:");
                string lastName = Console.ReadLine();

                Console.WriteLine("Enter email:");
                string email = Console.ReadLine();

                Console.WriteLine("Enter phone number:");
                string phone = Console.ReadLine();

                Console.WriteLine("Enter DOB (yyyy-mm-dd):");
                DateTime dob = DateTime.Parse(Console.ReadLine());

                // Add new student
                Student student = new Student(studentId, firstName, lastName, dob, email, phone);
                sis.Students.Add(student);

                Console.WriteLine("New student added successfully.");
            }

            // Save the data to file
            sis.SaveData();
        }
    }
}
