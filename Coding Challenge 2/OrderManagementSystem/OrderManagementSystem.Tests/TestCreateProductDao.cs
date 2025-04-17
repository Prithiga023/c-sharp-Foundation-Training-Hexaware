using NUnit.Framework;
using Order_Management_System.dao;
using OrderManagementSystem.Entity;

namespace OrderManagementSystem.Tests
{
    public class TestCreateProductDao
    {
        private ICreateProductDao _createProductDao;

        [SetUp]
        public void Setup()
        {
            _createProductDao = new CreateProductDao();
        }
        [Test]
        public void CreateProduct_ShouldReturnTrue_ForAdminUser()
        {
            var user = new User { UserId = 1001, Username = "admin", Role = "Admin" };
            var product = new Product { ProductId = 501, ProductName = "Laptop", Price = 25000 };
            var result = _createProductDao.CreateProduct(user, product);
            Assert.That(result, Is.True);
        }

        [Test]
        public void CreateProduct_ShouldThrowException_ForNonAdminUser()
        {
            var user = new User { UserId = 1002, Username = "customer", Role = "Customer" };
            var product = new Product { ProductId = 502, ProductName = "Phone", Price = 15000 };

            Assert.Throws<UnauthorizedAccessException>(() => _createProductDao.CreateProduct(user, product));
        }
    }
}
