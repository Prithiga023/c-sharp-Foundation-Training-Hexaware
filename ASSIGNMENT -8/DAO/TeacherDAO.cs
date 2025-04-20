using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SISDatabaseProject.Entity;

namespace SISDatabaseProject.DAO
{
    public class TeacherDAO
    {
        public void AddTeacher(Teacher teacher)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Teacher (Name, Email, Expertise) VALUES (@Name, @Email, @Expertise)", conn);
            cmd.Parameters.AddWithValue("@Name", teacher.Name);
            cmd.Parameters.AddWithValue("@Email", teacher.Email);
            cmd.Parameters.AddWithValue("@Expertise", teacher.Expertise);
            cmd.ExecuteNonQuery();
        }
    }
}
