using ModelsLibrary.DtO_Models;
using ModelsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Controllers.Models;
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
        [Route("{ProductName}")]
        [HttpPost]
        public ActionResult Index(AddCart AddCart)
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null)
            {
                return RedirectToAction("Login", "Login");
            }

            ViewBag.size = AddCart.size;
            ViewBag.color = AddCart.color;
            ViewBag.num = AddCart.num;
            return View();
        }
    }
}