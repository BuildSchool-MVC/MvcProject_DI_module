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
            var order = repository.CheckStatus(1);
            Assert.IsTrue(order != null);
        }


        [TestMethod()]
        public void TestCreate()
        {
            Order model = new Order()
            {
                CustomerID = 3,
                Transport = "宅配",
                Payment = "信用卡",
                Status = "已完成",
            };
            OrderRepository orders = new OrderRepository();
            orders.Create(model);
            Assert.IsTrue(model.CustomerID ==3);
        }

        [TestMethod]
        public void TestDelete()
        {
            Order model = new Order()
            {
                OrderID = 12
            };
            OrderRepository Repository = new OrderRepository();
            Repository.Delete(model);
            var list = Repository.FindById(12);
            Assert.IsTrue(list == null);
        }

        [TestMethod()]
        public void TestUpdateStatus()
        {
            Order model = new Order()
            {
                OrderID = 2,
                Status = "已完成",
                StatusUpdateDay = DateTime.Now
            };
            OrderRepository orders = new OrderRepository();
            orders.UpdateStatus(model);
            Assert.IsTrue(model.Status == "已完成");
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
            var order = repository.FindById(1);
            Assert.IsTrue(order != null);
        }
    }
}
