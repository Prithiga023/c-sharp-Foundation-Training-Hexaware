using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Entity
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }

        public Teacher() { }

        public Teacher(int teacherId, string name, string department)
        {
            TeacherId = teacherId;
            Name = name;
            Department = department;
        }

        public override string ToString()
        {
            return $"TeacherID: {TeacherId}, Name: {Name}, Department: {Department}";
        }
    }
}


