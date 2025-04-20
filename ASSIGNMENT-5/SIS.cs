using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace demonew
{
    public class SIS
    {
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Course> Courses { get; set; } = new List<Course>();
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();

        private const string DataFile = "sis_data.json"; // Path to save and load data

       
        public SIS()
        {
            LoadData();
        }

        // Enroll student in a course
        public void EnrollStudentInCourse(Student student, Course course)
        {
            if (!student.GetEnrollments().Contains(course))
            {
                student.EnrollInCourse(course);
            }
        }

        // Record a payment for a student
        public void RecordPayment(Student student, decimal amount, DateTime paymentDate)
        {
            student.MakePayment(amount, paymentDate);
        }

        // Assign teacher to a course
        public void AssignTeacherToCourse(Teacher teacher, Course course)
        {
            course.AssignTeacher(teacher);
        }

        // Save data to a JSON file
        public void SaveData()
        {
            var data = new
            {
                Students = Students,
                Courses = Courses,
                Teachers = Teachers
            };

            string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(DataFile, jsonData);
        }

        // Load data from the JSON file
        public void LoadData()
        {
            if (File.Exists(DataFile))
            {
                string jsonData = File.ReadAllText(DataFile);
                var data = JsonConvert.DeserializeObject<dynamic>(jsonData);

                Students = data?.Students.ToObject<List<Student>>() ?? new List<Student>();
                Courses = data?.Courses.ToObject<List<Course>>() ?? new List<Course>();
                Teachers = data?.Teachers.ToObject<List<Teacher>>() ?? new List<Teacher>();
            }
        }

        // Add a new student
        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        // Find a student by ID
        public Student FindStudentById(int studentId)
        {
            return Students.FirstOrDefault(s => s.StudentId == studentId);
        }

        // Update student information
        public void UpdateStudentInfo(Student student, string firstName, string lastName, string email)
        {
            student.UpdateStudentInfo(firstName, lastName, email);
        }

        // Add a new course
        public void AddCourse(Course course)
        {
            Courses.Add(course);
        }

        // Add a new teacher
        public void AddTeacher(Teacher teacher)
        {
            Teachers.Add(teacher);
        }
    }
}
