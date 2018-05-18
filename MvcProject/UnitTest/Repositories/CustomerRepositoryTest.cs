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
        public void FindByCustomerId()
        {
            var repository = new CustomerRepository();
            var customer = repository.FindByCustomerId(1);
            Assert.IsTrue(customer!=null);
        }

        [TestMethod]
        public void CreateCustomer()
        {
            Customer customer = new Customer()
            {
                CustomerName = "coco",
                Birthday =new DateTime( 1991,05,12),
                Account = "coco123",
                Password = "123456788",
                Phone="0923455899",
                ShoppingCash = 0,
                Email= "coco123@gmail.com"
            };
            CustomerRepository Repository = new CustomerRepository();
            Repository.Create(customer);
            //var list = Repository.FindByCustomerId(1);
            Assert.IsTrue(customer.CustomerName== "coco");
        }
        [TestMethod]
        public void UpdateCustomer()
        {
            
            Customer customer = new Customer()
            {
                Account= "May123",
                CustomerName = "LinMay123",
                Password = "123456887",
                Phone = "0911111987",
                ShoppingCash = 10,
                Email="zxc987@gmail.com"
            };
            CustomerRepository Repository = new CustomerRepository();
            var list = Repository.FindByCustomerId(5);
            Repository.Update(customer);
            
            Assert.IsTrue(list.Account== "May123");
        }
        [TestMethod]
        public void DeleteCustomer()
        {
            Customer customer = new Customer()
            {
                CustomerID=5
            };
            CustomerRepository Repository = new CustomerRepository();
            Repository.Delete(customer);
            var list = Repository.FindByCustomerId(5);
            Assert.IsTrue(list == null);
        }
    }
    
}
