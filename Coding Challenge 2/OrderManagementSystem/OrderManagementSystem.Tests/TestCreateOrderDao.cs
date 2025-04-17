
using NUnit.Framework;
using Order_Management_System.dao;
using OrderManagementSystem.dao;
using OrderManagementSystem.Entity;
using System.Collections.Generic;

namespace OrderManagementSystem.Tests
{
    public class TestCreateOrderDao
    {
        private ICreateOrderDao _createOrderDao;

        [SetUp]
        public void Setup()
        {
            _createOrderDao = new CreateOrderDao();
        }

        [Test]
        public void CreateOrder_ShouldReturnTrue_ForValidOrder()
        {
            var user = new User { UserId = 1001, Username = "testuser1", Role = "Customer" };
            var productList = new List<Product>
            {
                new Product { ProductId = 501, ProductName = "Laptop", Price = 25000 }
            };

            var result = _createOrderDao.CreateOrder(user, productList);
            Assert.That(result, Is.True);
        }
    }
}
