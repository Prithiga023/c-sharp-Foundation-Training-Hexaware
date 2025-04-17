using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderManagementSystem.Entity;

namespace OrderManagementSystem.dao
{
    public interface IOrderManagementRepository
    {
        bool CreateUser(User user);
        bool CreateProduct(User user, Product product);
        bool CreateOrder(User user, List<Product> products);
        bool CancelOrder(int userId, int orderId);
        List<Product> GetAllProducts();
        List<Order> GetOrderByUser(User user);
    }
}
