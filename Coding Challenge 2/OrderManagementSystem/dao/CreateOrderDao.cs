using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Entity;

namespace Order_Management_System.dao
{
    public class CreateOrderDao : ICreateOrderDao
    {
        public bool CreateOrder(User user, List<Product> products)
        {
            Console.WriteLine($"[CreateOrderDao] Order created for user: {user.Username}");
            return true;
        }
    }
}
