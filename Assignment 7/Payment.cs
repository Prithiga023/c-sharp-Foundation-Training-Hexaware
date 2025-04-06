using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_7
{
    public class Payment
    {
        public Student Student { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public Payment(Student student, double amount, DateTime date)
        {
            Student = student;
            Amount = amount;
            PaymentDate = date;
        }
    }
}
