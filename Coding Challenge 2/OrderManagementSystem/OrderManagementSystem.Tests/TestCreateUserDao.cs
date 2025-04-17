using NUnit.Framework;
using Order_Management_System.dao;
using OrderManagementSystem.dao;
using OrderManagementSystem.Entity;

namespace OrderManagementSystem.Tests
{
    public class TestCreateUserDao
    {
        private ICreateUserDao _createUserDao;

        [SetUp]
        public void Setup()
        {
            _createUserDao = new CreateUserDao();
        }

        [Test]
        public void CreateUser_ShouldReturnTrue_ForValidUser()
        {
            var user = new User { UserId = 1001, Username = "testuser1", Role = "Customer" };
            var result = _createUserDao.CreateUser(user);
            Assert.That(result, Is.True);
        }
    }
}
