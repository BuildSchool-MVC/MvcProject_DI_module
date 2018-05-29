
using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;

namespace UnitTest.Repositories

{

    [TestClass]
    public class ProductPhotoRepositoryTest
    {

        [TestMethod()]
        public void CreateTest()
        {
            ProductPhotoRepository repository = new ProductPhotoRepository();
            ProductPhoto model = new ProductPhoto
            {
                ProductID = 1,
                PhotoPath = "url"
            };
            repository.Create(model);
            var photos = repository.FindById(1);
            Assert.IsTrue(photos.Count() == 4);
        }


        [TestMethod()]
        public void UpdateTest()
        {
            ProductPhotoRepository repository = new ProductPhotoRepository();
            ProductPhoto model = new ProductPhoto
            {
                PhotoID=1,
                ProductID = 1,
                PhotoPath = "a"
            };
            repository.Update(model);
            var photos = repository.FindById(1);
            Assert.IsTrue(photos.Count() > 0);
        }


        [TestMethod()]
        public void DeleteTest()
        {
            ProductPhotoRepository repository = new ProductPhotoRepository();
            ProductPhoto model = new ProductPhoto
            {
                PhotoID = 2
            };
            repository.Delete(model);
            var photos = repository.FindById(1);
            Assert.IsTrue(photos.Count() > 0);
        }


        [TestMethod]
        public void FindByIdTest()
        {
            ProductPhotoRepository repository = new ProductPhotoRepository();
            var photos=repository.FindById(2);
            Assert.IsTrue(photos.Count() > 0);
        }

        [TestMethod]
        public void GetAllTest()
        {
            ProductPhotoRepository repository = new ProductPhotoRepository();
            var photos = repository.GetAll();
            Assert.IsTrue(photos.Count() > 0);
        }

        [TestMethod()]
        public void FindPicByIdTest()
        {
            ProductPhotoRepository repository = new ProductPhotoRepository();
            var list = repository.FindPicById(27);

            Assert.IsTrue(list =="Aaaaa");
        }

    }
}

