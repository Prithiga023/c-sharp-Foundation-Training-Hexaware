using SIS.Entity;
using SIS.Util;
using System;
using System.Data.SqlClient;

namespace SIS.DAO
{
    public class EnrollmentDao
    {
        public void EnrollStudent(Enrollment enrollment)
        {
            using (SqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Enrollments (StudentId, CourseId, TeacherId, EnrollmentDate) VALUES (@sid, @cid, @tid, @date)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@sid", enrollment.StudentId);
                cmd.Parameters.AddWithValue("@cid", enrollment.CourseId);
                cmd.Parameters.AddWithValue("@tid", enrollment.TeacherId);
                cmd.Parameters.AddWithValue("@date", enrollment.EnrollmentDate);
                cmd.ExecuteNonQuery();
            }
        }
    }
}