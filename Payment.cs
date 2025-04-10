using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIS.Entity
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int StudentId { get; set; }
        public double Amount { get; set; }
        public string PaymentDate { get; set; }
        public string PaymentMethod { get; set; }

        public Payment(int paymentId, int studentId, double amount, string paymentDate, string paymentMethod)
        {
            PaymentId = paymentId;
            StudentId = studentId;
            Amount = amount;
            PaymentDate = paymentDate;
            PaymentMethod = paymentMethod;
        }
    }
}