using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;
using ModelsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTest.Repositories
{
    [TestClass]
    public class ShoppingcartDetailsServiceTest
    {
        ShoppingcartDetailsService service = new ShoppingcartDetailsService();

        [TestMethod]
        public void AddProducttoShoppingcarTest()
        {
            var model = new ShoppingcartDetails()
            {
                CustomerID = 1,
                ProductID = 3,
                Quantity = 1
            };
            service.AddProducttoShoppingcar(model);
            var list=service.FindById(1, 3);
            Assert.IsTrue(list.Quantity ==1);
        }

        [TestMethod]
        public void ConfirmOrdersTest()
        {
            List<ShoppingcartDetails> shoppingcar = new List<ShoppingcartDetails>();
            shoppingcar.Add(new ShoppingcartDetails() { CustomerID = 3, ProductID = 2, Quantity = 1 });
            shoppingcar.Add(new ShoppingcartDetails() { CustomerID = 3, ProductID = 4, Quantity = 1 });
            Order order = new Order
            {
                CustomerID = 3,
                Transport = "宅配",
                Payment = "信用卡",
                Status = "處理中",
                Address="香山街23號"
            };
            var result=service.ConfirmOrders(shoppingcar, order);

            Assert.IsTrue(result == "OrderSuccess");
        }

        [TestMethod]
        public void CancelorderTest()
        {
            OrderService orderService = new OrderService();
            var result=orderService.Cancelorder(1);

            Assert.IsTrue(result == true);
        }
    }
}