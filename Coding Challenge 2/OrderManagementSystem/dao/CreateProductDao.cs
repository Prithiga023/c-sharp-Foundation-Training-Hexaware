using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Entity;

namespace Order_Management_System.dao
{
    public class CreateProductDao : ICreateProductDao
    {
        public bool CreateProduct(User user, Product product)
        {
            if (user.Role == "Admin")
            {
                Console.WriteLine($"[CreateProductDao] Product added: {product.ProductName}");
                return true;
            }
            else
            {
                throw new UnauthorizedAccessException("Only admins can add products.");
            }
        }
    }
}
