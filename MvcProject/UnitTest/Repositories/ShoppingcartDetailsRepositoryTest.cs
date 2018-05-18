using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;

namespace UnitTest.Repositories

{

    [TestClass]
    public class ShoppingcartDetailsRepositoryTest
    {

        [TestMethod()]
        public void CreateTest()
        {
            ShoppingcartDetailsRepository repository = new ShoppingcartDetailsRepository();
            ShoppingcartDetails model = new ShoppingcartDetails
            {
                ProductID = 1,
                CustomerID = 1,
                Quantity = 1
            };
            repository.Create(model);
            var shoppingcar = repository.GetAll();
            Assert.IsTrue(shoppingcar.Count() > 0);
        }


        [TestMethod()]
        public void UpdateTest()
        {
            ShoppingcartDetailsRepository repository = new ShoppingcartDetailsRepository();
            ShoppingcartDetails model = new ShoppingcartDetails
            {
                CustomerID = 1,
                ProductID = 1,
                Quantity = 1
            };
            repository.Update(model);
            var shoppingcar = repository.GetAll();
            Assert.IsTrue(shoppingcar.Count() > 0);
        }


        [TestMethod()]
        public void DeleteAllForUserTest()
        {
            ShoppingcartDetailsRepository repository = new ShoppingcartDetailsRepository();
            ShoppingcartDetails model = new ShoppingcartDetails
            {
                CustomerID = 1
            };
            repository.DeleteAllForUser(model);
            var shoppingcar = repository.FindByCustomer(1);
            Assert.IsTrue(shoppingcar.Count() == 0);
        }

        [TestMethod()]
        public void DeleteOneForUserTest()
        {
            ShoppingcartDetailsRepository repository = new ShoppingcartDetailsRepository();
            ShoppingcartDetails model = new ShoppingcartDetails
            {
                CustomerID = 1,
                ProductID = 1
            };
            var shoppingcar = repository.GetAll();
            Assert.IsTrue(shoppingcar.Count() > 0);
        }


        [TestMethod]
        public void FindByIdTest()
        {
            ShoppingcartDetailsRepository repository = new ShoppingcartDetailsRepository();
            var shoppingcar = repository.FindById(1,3);
            Assert.IsTrue(shoppingcar == null);
        }

        [TestMethod]
        public void GetAllTest()
        {
            ShoppingcartDetailsRepository repository = new ShoppingcartDetailsRepository();
            var shoppingcar = repository.GetAll();
            Assert.IsTrue(shoppingcar.Count() > 0);
        }

        [TestMethod]
        public void GetProductTotalTest()
        {
            ShoppingcartDetailsRepository repository = new ShoppingcartDetailsRepository();
            var shoppingcar = repository.GetProductTotal(1);
            Assert.IsTrue(shoppingcar > 0);
        }

        [TestMethod]
        public void FindByCustomerTest()
        {
            ShoppingcartDetailsRepository repository = new ShoppingcartDetailsRepository();
            var shoppingcar = repository.FindByCustomer(1);
            Assert.IsTrue(shoppingcar.Count() > 0);
        }
    }
}
