using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Entity;

namespace Order_Management_System.dao
{
    public class GetOrdersByUserDao : IGetOrdersByUserDao
    {
        public List<Order> GetOrderByUser(User user)
        {
            Console.WriteLine($"[GetOrdersByUserDao] Fetching orders for user: {user.Username}");
            return new List<Order>();
        }
    }
}
