using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Entity;

namespace OrderManagementSystem.dao
{
    public class OrderProcessor : IOrderManagementRepository
    {
        public bool CreateUser(User user)
        {
            // Implement logic to create a user in the database.
            // Make sure to check if the user already exists using the database.
            // If successful, return true.
            return true;
        }

        public bool CreateProduct(User user, Product product)
        {
            if (user.Role == "Admin")
            {
                // Add the product to the Product table in the database.
                return true;
            }
            else
            {
                throw new UnauthorizedAccessException("Only admins can add products.");
            }
        }

        public bool CreateOrder(User user, List<Product> products)
        {
            // Check if the user exists.
            // Create the order and add product details to OrderDetails table.
            return true;
        }

        public bool CancelOrder(int userId, int orderId)
        {
            // Check if order and user exist, cancel order and remove it from the database.
            return true;
        }

        public List<Product> GetAllProducts()
        {
            // Retrieve all products from the Product table.
            return new List<Product>(); // Placeholder return.
        }

        public List<Order> GetOrderByUser(User user)
        {
            // Get all orders by a specific user from the database.
            return new List<Order>(); // Placeholder return.
        }
    }
}
