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
        public void FindByCustomerAccount()
        {
            var repository = new CustomerRepository();
            var customer = repository.FindByCustomerAccount("coco");
            Assert.IsTrue(customer!=null);
        }

        [TestMethod]
        public void CreateCustomer()
        {
            Customer customer = new Customer()
            {
                CustomerName = "Jay",
                Birthday =new DateTime( 1999,12,12),
                Account = "JayJay",
                Password = "123",
                Phone="0923456432",
                ShoppingCash = 0,
                Email="qwe"
            };
            CustomerRepository Repository = new CustomerRepository();
            Repository.Create(customer);
            var list = Repository.FindByCustomerAccount("JayJay");
            Assert.IsTrue(list != null);
        }
        [TestMethod]
        public void UpdateCustomer()
        {
            
            Customer customer = new Customer()
            {
                Account= "JayJay",
                CustomerName ="Lin",
                Password = "123456",
                Phone = "0911111",
                ShoppingCash = 1000,
                Email="zxczxc"
            };
            CustomerRepository Repository = new CustomerRepository();
            var list = Repository.FindByCustomerAccount("JayJay");
            Repository.Update(customer);
            
            Assert.IsTrue(list.CustomerName== "Lin");
        }
        [TestMethod]
        public void DeleteCustomer()
        {
            Customer customer = new Customer()
            {
                Account="JayJay"
            };
            CustomerRepository Repository = new CustomerRepository();
            Repository.Delete(customer);
            var list = Repository.FindByCustomerAccount("JayJay");
            Assert.IsTrue(list == null);
        }
    }
    
}
