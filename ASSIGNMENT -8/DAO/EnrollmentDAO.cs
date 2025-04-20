using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SISDatabaseProject.Entity;

namespace SISDatabaseProject.DAO
{
    public class EnrollmentDAO
    {
        public void EnrollStudent(Enrollment enrollment)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Enrollment (StudentId, CourseId, EnrollmentDate) VALUES (@StudentId, @CourseId, @Date)", conn);
            cmd.Parameters.AddWithValue("@StudentId", enrollment.StudentId);
            cmd.Parameters.AddWithValue("@CourseId", enrollment.CourseId);
            cmd.Parameters.AddWithValue("@Date", enrollment.EnrollmentDate);
            cmd.ExecuteNonQuery();
        }
    }
}
