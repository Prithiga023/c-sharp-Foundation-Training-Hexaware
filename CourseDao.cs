using SIS.Entity;
using SIS.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SIS.DAO
{
    public class CourseDao
    {
        public void AddCourse(Course course)
        {
            using (SqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Courses (CourseId, CourseName, Credits) VALUES (@id, @name, @credits)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", course.CourseId);
                cmd.Parameters.AddWithValue("@name", course.CourseName);
                cmd.Parameters.AddWithValue("@credits", course.Credits);
                cmd.ExecuteNonQuery();
            }
        }
    }
}