using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Services
{
    [TestClass]
    public class PasswordValidationServiceTest
    {
        CustomerService service = new CustomerService();

        [TestMethod]
        public void CreateCustomerTest()
        {
            Customer customer = new Customer()
            {
                CustomerName = "coco",
                Birthday = new DateTime(1991, 05, 12),
                Account = "coco123",
                Password = "123456788",
                Phone = "0923455899",
                Email = "coco123@gmail.com"
            };
            service.Create(customer);
            Assert.IsTrue(customer.CustomerName == "coco");
        }

        [TestMethod]
        public void UpdatePasswordTest()
        {
            
            Customer customer = new Customer()
            {
                CustomerID = 1,
                Password = "0312958",
            };
            service.UpdatePassword(customer);
            Assert.IsTrue(customer.CustomerID == 1);
        }

        [TestMethod]
        public void PasswordsCheckTest()
        {
            PasswordSaltService passwordSaltService = new PasswordSaltService();
            var customer = service.FindByCustomerId(1);
            var result=passwordSaltService.PasswordsCheck(customer, "0312958");
            Assert.IsTrue(result==true);
        }
    }
}
