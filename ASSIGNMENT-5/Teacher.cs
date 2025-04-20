using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonew
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        private List<Course> assignedCourses = new List<Course>();

        public Teacher(int teacherId, string firstName, string lastName, string email)
        {
            TeacherId = teacherId;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        // Assign course to teacher
        public void AssignCourse(Course course)
        {
            if (!assignedCourses.Contains(course))
            {
                assignedCourses.Add(course);
            }
        }

        // Get the courses assigned to the teacher
        public List<Course> GetAssignedCourses()
        {
            return assignedCourses;
        }
    }
}

