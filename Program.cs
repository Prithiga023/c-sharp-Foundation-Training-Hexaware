using System;
using System.Collections.Generic;
using SIS.Dao;
using SIS.DAO;
using SIS.Entity;

namespace SIS
{
    class Program
    {
        static void Main(string[] args)
        {
            StudentDao studentDao = new StudentDao();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n----- Student Information System -----");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();
                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        AddStudent(studentDao);
                        break;
                    case "2":
                        ViewStudents(studentDao);
                        break;
                    case "3":
                        UpdateStudent(studentDao);
                        break;
                    case "4":
                        DeleteStudent(studentDao);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }

        static void AddStudent(StudentDao studentDao)
        {
            try
            {
                Console.Write("Enter Student ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Email: ");
                string email = Console.ReadLine();

                Student student = new Student(id, name, age, email);
                studentDao.AddStudent(student);
                Console.WriteLine("Student added successfully.");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error adding student: " + ex.Message);
            }
        }

        static void ViewStudents(StudentDao studentDao)
        {
            try
            {
                List<Student> students = studentDao.GetAllStudents();
                if (students.Count == 0)
                {
                    Console.WriteLine("No student records found.");
                }
                else
                {
                    Console.WriteLine("Current Students:");
                    foreach (Student student in students)
                    {
                        Console.WriteLine($"ID: {student.StudentId}, Name: {student.Name}, Age: {student.Age}, Email: {student.Email}");
                    }
                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error retrieving students: " + ex.Message);
            }
        }

        static void UpdateStudent(StudentDao studentDao)
        {
            try
            {
                Console.Write("Enter Student ID to update: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter new Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter new Age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter new Email: ");
                string email = Console.ReadLine();

                Student student = new Student(id, name, age, email);
                studentDao.UpdateStudent(student);
                Console.WriteLine("Student updated successfully.");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error updating student: " + ex.Message);
            }
        }

        static void DeleteStudent(StudentDao studentDao)
        {
            try
            {
                Console.Write("Enter Student ID to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());
                studentDao.DeleteStudent(id);
                Console.WriteLine("Student deleted successfully.");
            }
            catch (System.Exception ex)
            {
                Console.WriteLine("Error deleting student: " + ex.Message);
            }
        }
    }
}
