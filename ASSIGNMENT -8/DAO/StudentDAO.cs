using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SISDatabaseProject.Entity;

namespace SISDatabaseProject.DAO
{
    public class StudentDAO
    {
        public void AddStudent(Student student)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Student (FirstName, LastName, DateOfBirth, Email, PhoneNumber, OutstandingBalance) VALUES (@FirstName, @LastName, @DOB, @Email, @Phone, @Balance)", conn);
            cmd.Parameters.AddWithValue("@FirstName", student.FirstName);
            cmd.Parameters.AddWithValue("@LastName", student.LastName);
            cmd.Parameters.AddWithValue("@DOB", student.DateOfBirth);
            cmd.Parameters.AddWithValue("@Email", student.Email);
            cmd.Parameters.AddWithValue("@Phone", student.PhoneNumber);
            cmd.Parameters.AddWithValue("@Balance", student.OutstandingBalance);
            cmd.ExecuteNonQuery();
        }
    }
}
