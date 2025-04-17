
using NUnit.Framework;
using OrderManagementSystem.dao;
using OrderManagementSystem.Entity;
using System.Collections.Generic;


using Order_Management_System.dao;

 // Fixed namespace casing  

namespace OrderManagementSystem.Tests
{
    public class TestGetOrdersByUserDao
    {
        private IGetOrdersByUserDao _getOrdersByUserDao;

        [SetUp]
        public void Setup()
        {
            // Fix: Ensure the correct namespace and class are used  
            _getOrdersByUserDao = new GetOrdersByUserDao();
        }

        [Test]
        public void GetOrderByUser_ShouldReturnListOfOrders_ForValidUser()
        {
            var user = new User { UserId = 1001, Username = "testuser1", Role = "Customer" };
            var orders = _getOrdersByUserDao.GetOrderByUser(user);

            Assert.That(orders, Is.Not.Null);
            Assert.That(orders, Is.InstanceOf<List<Order>>());
        }
    }
}

