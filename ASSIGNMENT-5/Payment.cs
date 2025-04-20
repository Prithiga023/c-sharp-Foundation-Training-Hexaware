using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demonew
{
    public class Payment
    {
        public Student Student { get; }
        public decimal Amount { get; }
        public DateTime PaymentDate { get; }

        public Payment(Student student, decimal amount, DateTime paymentDate)
        {
            Student = student;
            Amount = amount;
            PaymentDate = paymentDate;
        }
    }
}

