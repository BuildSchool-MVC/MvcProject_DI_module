using ModelsLibrary.DtO_Models;
using ModelsLibrary.Services;
using ModelsLibrary.ViewModels;
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
        public ActionResult Clothes(string sortmethod)
        {
            var service = new CategoriesService();
            var photoService = new ProductPhotoService();
            var query = service.ClassifyByCategoryNameAndNullDownTime("上衣");
            query = query.Where((x) => x.Downtime==null).ToList();
            var photo_list = new List<ProductPhoto>();
            if(sortmethod != null)
            {
                if(sortmethod == "Time")
                    query = query.OrderByDescending((x) => x.Uptime).ToList();
                if (sortmethod == "TimeDESC")
                    query = query.OrderBy((x) => x.Uptime).ToList();
                if (sortmethod == "Price")
                    query = query.OrderByDescending((x) => x.UnitPrice).ToList();
                if (sortmethod == "PriceDESC")
                    query = query.OrderBy((x) => x.UnitPrice).ToList();
            }

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
        public ActionResult Pants(string sortmethod)
        {
            var service = new CategoriesService();
            var photoService = new ProductPhotoService();
            var query = service.ClassifyByCategoryNameAndNullDownTime("下著");
            if (sortmethod != null)
            {
                if (sortmethod == "Time")
                    query = query.OrderByDescending((x) => x.Uptime).ToList();
                if (sortmethod == "TimeDESC")
                    query = query.OrderBy((x) => x.Uptime).ToList();
                if (sortmethod == "Price")
                    query = query.OrderByDescending((x) => x.UnitPrice).ToList();
                if (sortmethod == "PriceDESC")
                    query = query.OrderBy((x) => x.UnitPrice).ToList();
            }

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
        public ActionResult Accessories(string sortmethod)
        {
            var service = new CategoriesService();
            var photoService = new ProductPhotoService();
            var query = service.ClassifyByCategoryNameAndNullDownTime("飾品");
            query = query.Where((x) => x.Downtime == null).ToList();
            if (sortmethod != null)
            {
                if (sortmethod == "Time")
                    query = query.OrderByDescending((x) => x.Uptime).ToList();
                if (sortmethod == "TimeDESC")
                    query = query.OrderBy((x) => x.Uptime).ToList();
                if (sortmethod == "Price")
                    query = query.OrderByDescending((x) => x.UnitPrice).ToList();
                if (sortmethod == "PriceDESC")
                    query = query.OrderBy((x) => x.UnitPrice).ToList();
            }

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
        public ActionResult Shoes(string sortmethod)
        {
            var service = new CategoriesService();
            var photoService = new ProductPhotoService();
            var query = service.ClassifyByCategoryNameAndNullDownTime("鞋子");
            query = query.Where((x) => x.Downtime == null).ToList();
            if (sortmethod != null)
            {
                if (sortmethod == "Time")
                    query = query.OrderByDescending((x) => x.Uptime).ToList();
                if (sortmethod == "TimeDESC")
                    query = query.OrderBy((x) => x.Uptime).ToList();
                if (sortmethod == "Price")
                    query = query.OrderByDescending((x) => x.UnitPrice).ToList();
                if (sortmethod == "PriceDESC")
                    query = query.OrderBy((x) => x.UnitPrice).ToList();
            }

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
        public ActionResult Bags(string sortmethod)
        {
            var service = new CategoriesService();
            var photoService = new ProductPhotoService();
            var query = service.ClassifyByCategoryNameAndNullDownTime("包包");
            query = query.Where((x) => x.Downtime == null).ToList();
            if (sortmethod != null)
            {
                if (sortmethod == "Time")
                    query = query.OrderByDescending((x) => x.Uptime).ToList();
                if (sortmethod == "TimeDESC")
                    query = query.OrderBy((x) => x.Uptime).ToList();
                if (sortmethod == "Price")
                    query = query.OrderByDescending((x) => x.UnitPrice).ToList();
                if (sortmethod == "PriceDESC")
                    query = query.OrderBy((x) => x.UnitPrice).ToList();
            }

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

        [Route("Search")]
        public ActionResult Search(string sortmethod)
        {
            var str = this.ControllerContext.HttpContext.Request.QueryString[0];
            var service = new ProductsService();
            var photoService = new ProductPhotoService();
            var list = service.GetAll().ToList();
            var query = new List<Products>();
            foreach (var item in list)
            {
                if (item.ProductName.Contains(str) && query.Any((x) => x.ProductName == item.ProductName) == false)
                {
                    query.Add(item);
                }
            }

            if (sortmethod != null)
            {
                if (sortmethod == "Time")
                    query = query.OrderByDescending((x) => x.Uptime).ToList();
                if (sortmethod == "TimeDESC")
                    query = query.OrderBy((x) => x.Uptime).ToList();
                if (sortmethod == "Price")
                    query = query.OrderByDescending((x) => x.UnitPrice).ToList();
                if (sortmethod == "PriceDESC")
                    query = query.OrderBy((x) => x.UnitPrice).ToList();
            }

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