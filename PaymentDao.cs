using SIS.Entity;
using SIS.Util;
using System;
using System.Data.SqlClient;

namespace SIS.DAO
{
    public class PaymentDao
    {
        public void RecordPayment(Payment payment)
        {
            using (SqlConnection conn = DBUtil.GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO Payments (PaymentId, StudentId, Amount, PaymentDate, PaymentMethod) VALUES (@pid, @sid, @amount, @date, @method)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@pid", payment.PaymentId);
                cmd.Parameters.AddWithValue("@sid", payment.StudentId);
                cmd.Parameters.AddWithValue("@amount", payment.Amount);
                cmd.Parameters.AddWithValue("@date", payment.PaymentDate);
                cmd.Parameters.AddWithValue("@method", payment.PaymentMethod);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
