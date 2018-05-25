using ModelsLibrary.DtO_Models;
using ModelsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [RoutePrefix("Product")]
    public class ProductController : Controller
    {
        // GET: Product
        [Route("{ProductName}")]
        public ActionResult Product(ProductList ProductList)
        {
            ProductsService service = new ProductsService();
            var product = service.FindByName(ProductList.ProductName);
            return View(product);
        }
    }
}