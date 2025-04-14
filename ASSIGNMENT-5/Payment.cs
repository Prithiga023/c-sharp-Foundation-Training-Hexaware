using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonew
{
    public class Payment
    {
        public int PaymentId;
        public Student Payer;
        public decimal AmountPaid;
        public DateTime PaymentDate;

        public Payment(int id, Student payer, decimal amount, DateTime date)
        {
            PaymentId = id;
            Payer = payer;
            AmountPaid = amount;
            PaymentDate = date;
        }

        public Student GetStudent() => Payer;
        public decimal GetPaymentAmount() => AmountPaid;
        public DateTime GetPaymentDate() => PaymentDate;
    }
}

