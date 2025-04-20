using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SISDatabaseProject.Entity;

namespace SISDatabaseProject.DAO
{
    public class CourseDAO
    {
        public void AddCourse(Course course)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Course (CourseName, CourseCode, TeacherId) VALUES (@Name, @Code, @TeacherId)", conn);
            cmd.Parameters.AddWithValue("@Name", course.CourseName);
            cmd.Parameters.AddWithValue("@Code", course.CourseCode);
            cmd.Parameters.AddWithValue("@TeacherId", (object?)course.TeacherId ?? DBNull.Value);
            cmd.ExecuteNonQuery();
        }
    }
}
