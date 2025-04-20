using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace SISDatabaseProject.Service
{
    public class DynamicQueryBuilder
    {
        public static DataTable SearchStudents(string? name = null, string? email = null, string? phone = null)
        {
            var query = new StringBuilder("SELECT * FROM Student WHERE 1=1");
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(name))
            {
                query.Append(" AND (FirstName LIKE @Name OR LastName LIKE @Name)");
                parameters.Add(new SqlParameter("@Name", $"%{name}%"));
            }

            if (!string.IsNullOrEmpty(email))
            {
                query.Append(" AND Email LIKE @Email");
                parameters.Add(new SqlParameter("@Email", $"%{email}%"));
            }

            if (!string.IsNullOrEmpty(phone))
            {
                query.Append(" AND PhoneNumber LIKE @Phone");
                parameters.Add(new SqlParameter("@Phone", $"%{phone}%"));
            }

            return ExecuteQuery(query.ToString(), parameters);
        }

        public static DataTable SearchCourses(string? courseName = null, string? courseCode = null)
        {
            var query = new StringBuilder("SELECT * FROM Course WHERE 1=1");
            var parameters = new List<SqlParameter>();

            if (!string.IsNullOrEmpty(courseName))
            {
                query.Append(" AND CourseName LIKE @CourseName");
                parameters.Add(new SqlParameter("@CourseName", $"%{courseName}%"));
            }

            if (!string.IsNullOrEmpty(courseCode))
            {
                query.Append(" AND CourseCode LIKE @CourseCode");
                parameters.Add(new SqlParameter("@CourseCode", $"%{courseCode}%"));
            }

            return ExecuteQuery(query.ToString(), parameters);
        }

        public static DataTable SearchPayments(int? studentId = null, DateTime? from = null, DateTime? to = null)
        {
            var query = new StringBuilder("SELECT * FROM Payment WHERE 1=1");
            var parameters = new List<SqlParameter>();

            if (studentId.HasValue)
            {
                query.Append(" AND StudentId = @StudentId");
                parameters.Add(new SqlParameter("@StudentId", studentId.Value));
            }

            if (from.HasValue)
            {
                query.Append(" AND PaymentDate >= @FromDate");
                parameters.Add(new SqlParameter("@FromDate", from.Value));
            }

            if (to.HasValue)
            {
                query.Append(" AND PaymentDate <= @ToDate");
                parameters.Add(new SqlParameter("@ToDate", to.Value));
            }

            return ExecuteQuery(query.ToString(), parameters);
        }

        private static DataTable ExecuteQuery(string query, List<SqlParameter> parameters)
        {
            using var conn = DAO.DatabaseManager.GetConnection();
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddRange(parameters.ToArray());
            var dt = new DataTable();

            using var adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);

            return dt;
        }
    }
}
