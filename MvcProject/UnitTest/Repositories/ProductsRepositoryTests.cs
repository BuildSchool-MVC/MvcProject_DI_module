﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.Repositories.Tests
{
    [TestClass()]
    public class ProductsRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            ProductsRepository repository = new ProductsRepository();
            var list=repository.GetAll();
            Assert.IsTrue(list.Count()>0);
        }

        [TestMethod()]
        public void GetColorTest()
        {
            ProductsRepository repository = new ProductsRepository();
            var list = repository.GetbyColor("Red");
            Assert.IsTrue(list.Count()>1 );
        }

        [TestMethod()]
        public void FindByIDTest()
        {
            ProductsRepository products = new ProductsRepository();
            var list = products.FindByID(2);

            Assert.IsTrue(list != null);
        }

        [TestMethod()]
        public void FindByID2Test()
        {
            ProductsRepository products = new ProductsRepository();
            var list = products.FindByID(4);

            Assert.IsTrue(list.CategoryID == 1);
        }

        [TestMethod()]
        public void CreateTest()
        {
            Products model = new Products()
            {
                ProductName = "高腰開岔長裙",
                UnitPrice = 200,
                UnitsInStock = 50,
                CategoryID = 3,
                Size = "S",
                Color = "Red",
                Uptime = new DateTime(2018, 05, 10),
                ProductDetails = "左右兩側附口袋"
            };
            ProductsRepository products = new ProductsRepository();
            products.Create(model);
            var list = products.FindByID(2);

            Assert.IsTrue(list != null);
        }

        [TestMethod()]
        public void UpdateUnitPriceTest()
        {
            Products model = new Products()
            {
                ProductID = 4,
                UnitPrice = 220
            };
            ProductsRepository products = new ProductsRepository();
            products.UpdateUnitPrice(model);
            var list = products.FindByID(4);

            Assert.IsTrue(list.UnitPrice==220);
        }

        [TestMethod()]
        public void UpdateStockPplusTest()
        {
            Products model = new Products()
            {
                ProductID = 4
            };
            ProductsRepository products = new ProductsRepository();
            products.UpdateStockPplus(model,20);
            var list = products.FindByID(4);

            Assert.IsTrue(list.UnitsInStock==45);
        }

        [TestMethod()]
        public void UpdateStockPminusTest()
        {
            Products model = new Products()
            {
                ProductID = 4
            };
            ProductsRepository products = new ProductsRepository();
            products.UpdateStockPminus(model, 20);
            var list = products.FindByID(4);

            Assert.IsTrue(list.UnitsInStock == 25);
        }

        [TestMethod()]
        public void UpdateDowntimeTest()
        {
            Products model = new Products()
            {
                ProductID = 4,
                Downtime=new DateTime(2018,05,12)
            };
            ProductsRepository products = new ProductsRepository();
            products.UpdateDowntime(model);
            var list = products.FindByID(4);

            Assert.IsTrue(list.Downtime == model.Downtime);
        }

        [TestMethod()]
        public void UpdateProductDetailsTest()
        {
            Products model = new Products()
            {
                ProductID = 4
            };
            ProductsRepository products = new ProductsRepository();
            products.UpdateProductDetails(model,"洗滌不退色");
            var list = products.FindByID(4);

            Assert.IsTrue(list.Downtime == model.Downtime);
        }

        [TestMethod()]
        public void GetProductNameTest()
        {
            ProductsRepository products = new ProductsRepository();
            var list=products.GetbyProductName("高");

            Assert.IsTrue(list.Count()>0);
        }

        [TestMethod()]
        public void GetSizebyProductNamebyColorTest()
        {
            ProductsRepository products = new ProductsRepository();
            var list = products.GetSizebyProductNamebyColor("紅色高跟鞋", "紅");

            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod()]
        public void CheckStockTest()
        {
            ProductsRepository products = new ProductsRepository();
            var list = products.CheckStock(2,2);

            Assert.IsTrue(list == true);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Products model = new Products()
            {
                ProductID = 3
            };
            ProductsRepository products = new ProductsRepository();
            products.Delete(model);
            var list = products.FindByID(3);

            Assert.IsTrue(list == null);
        }
        [TestMethod()]
        public void FindByName()
        {
            Products model = new Products()
            {
                ProductName="紅色高跟鞋"
            };
            ProductsRepository products = new ProductsRepository();
            var list= products.FindByName("紅色高跟鞋");
            Assert.IsTrue(list .Count()>0);
        }
        [TestMethod()]
        public void FindIdByName()
        {
            ProductsRepository products = new ProductsRepository();
            var list = products.FindIdByName("紅色高跟鞋", "23", "紅");
            Assert.IsTrue(list!=null);
        }

        [TestMethod]
        public void GetBestProducts()
        {
            ProductsRepository repository = new ProductsRepository();
            var list = repository.GetBestProducts();
            Assert.IsTrue(list.Count()==3);
        }

    }
}