using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order_Management_System.dao
{
    public class CancelOrderDao : ICancelOrderDao
    {
        public bool CancelOrder(int userId, int orderId)
        {
            Console.WriteLine($"[CancelOrderDao] Order {orderId} cancelled by user {userId}");
            return true;
        }
    }
}
