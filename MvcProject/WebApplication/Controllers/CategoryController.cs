using ModelsLibrary.DtO_Models;
using ModelsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    [RoutePrefix("Category")]
    public class CategoryController : Controller
    {
        // GET: Category
        [Route("Clothes")]
        public ActionResult Clothes()
        {
            var service = new CategoriesService();
            var photoService = new ProductPhotoService();
            var query = service.ClassifyByCategoryName("上衣");

            var photo_list = new List<ProductPhoto>();
            foreach(var item in query)
            {
                photo_list.Add(photoService.FindById(item.ProductID).First());
            }

            ViewData.Add("photo_list", photo_list);
            ViewData.Add("count", query.Count());
            ViewData.Add("list", query);
            return View();
        }

        [Route("Pants")]
        public ActionResult Pants()
        {
            var service = new CategoriesService();
            var photoService = new ProductPhotoService();
            var query = service.ClassifyByCategoryName("下著");

            var photo_list = new List<ProductPhoto>();
            foreach (var item in query)
            {
                photo_list.Add(photoService.FindById(item.ProductID).First());
            }

            ViewData.Add("photo_list", photo_list);
            ViewData.Add("count", query.Count());
            ViewData.Add("list", query);
            return View();
        }

        [Route("Accessories")]
        public ActionResult Accessories()
        {
            var service = new CategoriesService();
            var photoService = new ProductPhotoService();
            var query = service.ClassifyByCategoryName("飾品");

            var photo_list = new List<ProductPhoto>();
            foreach (var item in query)
            {
                photo_list.Add(photoService.FindById(item.ProductID).First());
            }

            ViewData.Add("photo_list", photo_list);
            ViewData.Add("count", query.Count());
            ViewData.Add("list", query);
            return View();
        }

        [Route("Shoes")]
        public ActionResult Shoes()
        {
            var service = new CategoriesService();
            var photoService = new ProductPhotoService();
            var query = service.ClassifyByCategoryName("鞋子");
           
            var photo_list = new List<ProductPhoto>();
            foreach (var item in query)
            {
                photo_list.Add(photoService.FindById(item.ProductID).First());
            }

            ViewData.Add("photo_list", photo_list);
            ViewData.Add("count", query.Count());
            ViewData.Add("list", query);
            return View();
        }

        [Route("Bags")]
        public ActionResult Bags()
        {
            var service = new CategoriesService();
            var photoService = new ProductPhotoService();
            var query = service.ClassifyByCategoryName("包包");

            var photo_list = new List<ProductPhoto>();
            foreach (var item in query)
            {
                photo_list.Add(photoService.FindById(item.ProductID).First());
            }

            ViewData.Add("photo_list", photo_list);
            ViewData.Add("count", query.Count());
            ViewData.Add("list", query);
            return View();
        }
    }
}