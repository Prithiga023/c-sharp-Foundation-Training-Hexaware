using SIS.Entity;
using SIS.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SIS.DAO
{
    public class TeacherDao
    {
        public void AddTeacher(Teacher teacher)
        {
            using (SqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Teachers (TeacherId, Name, Department) VALUES (@id, @name, @dept)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", teacher.TeacherId);
                cmd.Parameters.AddWithValue("@name", teacher.Name);
                cmd.Parameters.AddWithValue("@dept", teacher.Department);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            using (SqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM Teachers";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    teachers.Add(new Teacher(
                        Convert.ToInt32(reader["TeacherId"]),
                        reader["Name"].ToString(),
                        reader["Department"].ToString()
                    ));
                }
            }
            return teachers;
        }
    }
}


