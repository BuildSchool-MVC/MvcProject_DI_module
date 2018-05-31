using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelsLibrary.Services;

namespace WebApplication.Controllers.Admin
{
    [RoutePrefix("Admin")]
    public class ProductController : Controller
    {
        [Route("Product")]
        // GET: Product
        public ActionResult AdminProduct()
        {
            ProductsService ProductsService = new ProductsService();
            var query = ProductsService.GetAll();
            ViewData.Add("count", query.Count());
            ViewData.Add("list", query);
            return View();
        }

        [Route("ProductAdd")]
        public ActionResult AdminProductAdd()
        {
            return View();
        }

        [Route("ProductUpdate")]
        public ActionResult AdminProductUpdate()
        {
            return View();
        }
    }
}