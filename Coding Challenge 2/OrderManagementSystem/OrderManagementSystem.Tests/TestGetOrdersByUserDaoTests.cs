
using NUnit.Framework;
using Order_Management_System.dao;
using OrderManagementSystem.Entity;
using System.Collections.Generic; // Ensure this is included for List<T>  

namespace OrderManagementSystem.Tests
{
    public class TestGetOrdersByUserDaoTests  
    {
        private IGetOrdersByUserDao _getOrdersByUserDao;

        [SetUp]
        public void Setup()
        {
            _getOrdersByUserDao = new GetOrdersByUserDao();  
        }

        [Test]
        public void GetOrderByUser_ShouldReturnListOfOrders_ForValidUser()
        {
            var user = new User { UserId = 1001, Username = "testuser1", Role = "Customer" };
            var orders = _getOrdersByUserDao.GetOrderByUser(user);

            Assert.That(orders, Is.Not.Null); // Replace Assert.IsNotNull with Assert.That and Is.Not.Null  
            Assert.That(orders, Is.InstanceOf<List<Order>>());
        }
    }
}
