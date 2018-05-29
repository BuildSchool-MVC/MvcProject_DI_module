using ModelsLibrary.DtO_Models;
using ModelsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    [RoutePrefix("")]
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home")]
        public ActionResult Index()
        {
            var servicePro = new ProductsService();
            var servicePh = new ProductPhotoService();
            var BestProducts = servicePro.GetBestProducts();
            var NewProducts = servicePro.GetNewProducts();
            var BestProductsList = new List<ProductPhoto>();
            var BestProductsName = new List<Products>();
            var NewProductsList = new List<ProductPhoto>();
            var NewProductsName = new List<Products>();

            foreach (var item in BestProducts)
            {
                BestProductsList.Add(servicePh.FindPicById(item.ProductID));
            }
            foreach(var item in NewProducts)
            {
                NewProductsList.Add(servicePh.FindPicById(item.ProductID));
            }

            var NewProductsList2 = new List<string>();
            foreach (var item in NewProductsList)
            {
                if (NewProductsList2.Any((x) => x == item.PhotoPath) == false)
                {
                    NewProductsList2.Add(item.PhotoPath);
                    NewProductsName.Add(servicePro.FindByID(item.ProductID));
                }
            }

            var BestProductsList2 = new List<string>();
            foreach (var item in BestProductsList)
            {
                if (BestProductsList2.Any((x) => x == item.PhotoPath) == false)
                {
                    BestProductsList2.Add(item.PhotoPath);
                    BestProductsName.Add(servicePro.FindByID(item.ProductID));
                }
            }

            ViewData.Add("BestProductsList2", BestProductsList2);
            ViewData.Add("Bestcount", BestProductsList2.Count());
            ViewData.Add("BestProductsName", BestProductsName);
            ViewData.Add("NewProductsList2", NewProductsList2);
            ViewData.Add("Newcount", NewProductsList2.Count());
            ViewData.Add("NewProductsName", NewProductsName);
            return View();
        }

    }
}