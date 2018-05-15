using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;

namespace CustomerTest
{
    [TestClass]
    public class CustomerRepositoryTest
    {
        [TestMethod]
        public void CustomerGetAll()
        {
            var repository = new CustomerRepository();
            var customer = repository.GetAll();
            Assert.IsTrue(customer.Count() > 0);
        }
        [TestMethod]
        public void CustomerFindById()
        {
            var repository = new CustomerRepository();
            var customer = repository.FindById(1);
            Assert.IsTrue(customer.CustomerID==1);
        }
        [TestMethod]
        public void CreateCustomer()
        {
            Customer customer = new Customer()
            {
                CustomerID = 2,
                CustomerName = "Coco",
                Birthday =new DateTime( 1999,12,12),
                Account = "coco",
                Password = "123",
                Phone="0923456432",
                ShoppingCash = 0,
                Email="qwe"
            };
            CustomerRepository Repository = new CustomerRepository();
            Repository.Create(customer);
            var list = Repository.FindById(customer.CustomerID);
            Assert.IsTrue(list != null);
        }
        [TestMethod]
        public void UpdateCustomer()
        {
            Customer customer = new Customer()
            {
                CustomerID = 2,
                CustomerName = "Cococo",
                Password = "123456",
                Phone = "0911111",
                ShoppingCash = 100,
                Email="zxc"
            };
            CustomerRepository Repository = new CustomerRepository();
            Repository.Update(customer);
            var list = Repository.FindById(2);
            Assert.IsTrue(list.Password==customer.Password);
        }
        [TestMethod]
        public void DeleteCustomer()
        {
            Customer customer = new Customer()
            {
                CustomerID = 2
            };
            CustomerRepository Repository = new CustomerRepository();
            Repository.Delete(customer);
            var list = Repository.FindById(2);
            Assert.IsTrue(list != null);
        }
    }
    
}
