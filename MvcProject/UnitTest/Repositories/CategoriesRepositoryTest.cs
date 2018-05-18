using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UnitTest.Repositories
{
    [TestClass]
    public class CategoriesRepositoryTest
    {
        [TestMethod]
        public void GetAllTest()
        {
            var repository = new CategoriesRepository();
            var list = repository.GetAll().ToList();

            Assert.IsTrue(list.Count() > 0);
        }

        [TestMethod]
        public void GetByIDTest()
        {
            var repository = new CategoriesRepository();
            var result = repository.GetByID(1);

            Assert.IsTrue(result.CategoryName == "上衣");
        }

        [TestMethod]
        public void TestCreate()
        {
            Categories model = new Categories()
            {
                CategoryID = 6,
                CategoryName = "aaa"
            };
            CategoriesRepository Repository = new CategoriesRepository();
            Repository.Create(model);
            var result = Repository.GetByID(6);
            Assert.IsTrue(result.CategoryID ==6);
        }

        [TestMethod]
        public void TestDelete()
        {
            Categories model = new Categories()
            {
                CategoryID = 6
            };
            CategoriesRepository Repository = new CategoriesRepository();
            Repository.Delete(model);
            var list = Repository.GetByID(6);
            Assert.IsTrue(list == null);
        }
        
        [TestMethod]
        public void TestUpdateCategoryNameByID()
        {
            
            CategoriesRepository Repository = new CategoriesRepository();
            Repository.UpdateCategoryNameByID(1,"上衣");
            var list = Repository.GetByID(1);
            Assert.IsTrue(list.CategoryName == "上衣");
        }

        [TestMethod]
        public void TestGetByName()
        {
            var repository = new CategoriesRepository();
            var result = repository.GetByName("上衣");

            Assert.IsTrue(result.CategoryID == 1);
        }
    }
}
