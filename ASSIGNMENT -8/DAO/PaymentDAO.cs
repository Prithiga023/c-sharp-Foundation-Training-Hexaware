using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using SISDatabaseProject.Entity;

namespace SISDatabaseProject.DAO
{
    public class PaymentDAO
    {
        public void RecordPayment(Payment payment)
        {
            using var conn = DatabaseManager.GetConnection();
            conn.Open();
            var cmd = new SqlCommand("INSERT INTO Payment (StudentId, PaymentAmount, PaymentDate) VALUES (@StudentId, @Amount, @Date)", conn);
            cmd.Parameters.AddWithValue("@StudentId", payment.StudentId);
            cmd.Parameters.AddWithValue("@Amount", payment.PaymentAmount);
            cmd.Parameters.AddWithValue("@Date", payment.PaymentDate);
            cmd.ExecuteNonQuery();
        }
    }
}
