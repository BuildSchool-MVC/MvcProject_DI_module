using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;

namespace UnitTest
{
    [TestClass]
    public class OrderDetailsRepositoryTest
    {
        [TestMethod()]
        public void TestCreate()
        {
            OrderDetails model = new OrderDetails()
            {
                OrderID = 3,
                ProductID = 2,
                Quantity = 3

            };
            OrderDetailsRepository ordersDetail = new OrderDetailsRepository();
            ordersDetail.Create(model);
            Assert.IsTrue(model.OrderID ==3);
        }

        [TestMethod]
        public void TestUpdate()
        {

            OrderDetails model = new OrderDetails()
            {
                OrderID = 3,
                ProductID = 2,
                Quantity = 3

            };
            OrderDetailsRepository ordersDetail = new OrderDetailsRepository();
            var list = ordersDetail.FindById(3);
            ordersDetail.Update(model);
            Assert.IsTrue(model.OrderID == 3);
        }

        [TestMethod]
        public void TestDelete()
        {
            OrderDetails model = new OrderDetails()
            {
                OrderID = 3,
            };
            OrderDetailsRepository ordersDetail = new OrderDetailsRepository();
            ordersDetail.Delete(model);
            var list = ordersDetail.FindById(3);
            Assert.IsTrue(list == null);
        }

        [TestMethod]
        public void GetAll()
        {
            var repository = new OrderDetailsRepository();
            var orderdetails = repository.GetAll();
            Assert.IsTrue(orderdetails.Count() >0);
        }

        [TestMethod]
        public void FindById()
        {
            var repository = new OrderDetailsRepository();
            var orderdetails = repository.FindById(1);
            Assert.IsTrue(orderdetails != null);
        }

        [TestMethod]
        public void FindOrderDetail()
        {
            var repository = new OrderDetailsRepository();
            var orderdetails = repository.FindOrderDetail(9);
            Assert.IsTrue(orderdetails.Count() == 3);
        }

    }
    
}
