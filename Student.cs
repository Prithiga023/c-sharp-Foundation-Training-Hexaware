using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Entity
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public Student(int studentId, string name, int age, string email)
        {
            StudentId = studentId;
            Name = name;
            Age = age;
            Email = email;
        }
    }
}