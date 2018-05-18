using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.Repositories;

namespace UnitTest
{
    [TestClass]
    public class OrderDetailsRepositoryTest
    {
        [TestMethod]
        public void GetAll()
        {
            var repository = new OrderDetailsRepository();
            var orderdetails = repository.GetAll();
            Assert.IsTrue(orderdetails.Count() == 1);
        }

        [TestMethod]
        public void FindById()
        {
            var repository = new OrderDetailsRepository();
            var orderdetails = repository.FindById(1);
            Assert.IsTrue(orderdetails != null);
        }
    }
    
}
