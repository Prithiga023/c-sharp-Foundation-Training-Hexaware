
using NUnit.Framework;
using Order_Management_System.dao;
using OrderManagementSystem.dao;

namespace OrderManagementSystem.Tests
{
    public class TestCancelOrderDao
    {
        private ICancelOrderDao _cancelOrderDao;

        [SetUp]
        public void Setup()
        {
            _cancelOrderDao = new CancelOrderDao();
        }

        [Test]
        public void CancelOrder_ShouldReturnTrue_ForValidOrder()
        {
            var userId = 1001;
            var orderId = 101;
            var result = _cancelOrderDao.CancelOrder(userId, orderId);
            Assert.That(result, Is.True);
        }
    }
}
