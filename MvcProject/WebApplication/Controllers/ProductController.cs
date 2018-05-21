using ModelsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    [RoutePrefix("Product")]
    public class ProductController : Controller
    {
        // GET: Product
        [Route("{id}")]
        public ActionResult Product(int id)
        {
            ViewData.Add("id", id);
            return View();
        }

        public ActionResult Partial_Product(int id)
        {
            ProductsService service = new ProductsService();
            var result = service.FindByID(id);
            //ViewData.Add("x",re)
            return PartialView(result);
        }
    }
}