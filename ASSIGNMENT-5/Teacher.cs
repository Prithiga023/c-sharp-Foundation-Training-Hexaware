using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonew
{
    public class Teacher
    {
        public int TeacherId;
        public string FirstName;
        public string LastName;
        public string Email;
        public List<Course> AssignedCourses = new List<Course>();

        public Teacher(int id, string firstName, string lastName, string email)
        {
            TeacherId = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public void UpdateTeacherInfo(string name, string email, string expertise)
        {
            FirstName = name.Split(' ')[0];
            LastName = name.Split(' ')[1];
            Email = email;
        }

        public void DisplayTeacherInfo()
        {
            Console.WriteLine($"ID: {TeacherId}, Name: {FirstName} {LastName}, Email: {Email}");
        }

        public List<Course> GetAssignedCourses() => AssignedCourses;
    }
}

