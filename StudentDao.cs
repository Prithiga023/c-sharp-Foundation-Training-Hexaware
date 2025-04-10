using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIS.Entity;
using SIS.Util;


namespace SIS.Dao
{
    public class StudentDao
    {
        public void AddStudent(Student student)
        {
            using (SqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Student (StudentId, Name, Age, Email) VALUES (@StudentId, @Name, @Age, @Email)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Student";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int studentId = Convert.ToInt32(reader["StudentId"]);
                        string name = reader["Name"].ToString();
                        int age = Convert.ToInt32(reader["Age"]);
                        string email = reader["Email"].ToString();

                        students.Add(new Student(studentId, name, age, email));
                    }
                }
            }

            return students;
        }

        public void UpdateStudent(Student student)
        {
            using (SqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = "UPDATE Student SET Name=@Name, Age=@Age, Email=@Email WHERE StudentId=@StudentId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", student.StudentId);
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteStudent(int studentId)
        {
            using (SqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = "DELETE FROM Student WHERE StudentId=@StudentId";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentId", studentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}