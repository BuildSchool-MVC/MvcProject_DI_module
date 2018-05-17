using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;

namespace UnitTest.Repositories

{
   
    [TestClass]
    public class OrderRepositoryTest
    {
        [TestMethod]
        public void TestCheckStatus()
        {
            var repository = new OrderRepository();
            var order = repository.CheckStatus("1");
            Assert.IsTrue(order != null);
        }


        [TestMethod()]
        public void TestCreate()
        {
            Order model = new Order()
            {
                OrderID = 3,
                OrderDay = new DateTime(2018, 11, 07),
                CustomerID = 2,
                Transport = "宅配",
                Payment = "信用卡",
                Status = "處理中",
                StatusUpdateDay = DateTime.Now
            };
            OrderRepository orders = new OrderRepository();
            orders.Create(model);
            var list = orders.FindById(model.OrderID.ToString());
            Assert.IsTrue(list != null);
        }


        [TestMethod()]
        public void TestUpdateStatus()
        {
            Order model = new Order()
            {
                OrderID = 1,
                Status = "處理中",
                StatusUpdateDay = DateTime.Now
            };
            OrderRepository orders = new OrderRepository();
            orders.UpdateStatus(model);
            Assert.IsTrue(model.Status == "處理中");
        }


        [TestMethod]
        public void TestGetAll()
        {
            var repository = new OrderRepository();
            var order = repository.GetAll();
            Assert.IsTrue(order.Count() > 0);
        }

        [TestMethod]
        public void TestFindById()
        {
            var repository = new OrderRepository();
            var order = repository.FindById("1");
            Assert.IsTrue(order != null);
        }


    }
}
