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
    }
}
