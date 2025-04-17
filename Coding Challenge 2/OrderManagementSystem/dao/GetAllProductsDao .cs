using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Entity;

namespace Order_Management_System.dao
{
    public class GetAllProductsDao : IGetAllProductsDao
    {
        public List<Product> GetAllProducts()
        {
            Console.WriteLine("[GetAllProductsDao] Fetching all products...");
            return new List<Product>();
        }
    }
}
