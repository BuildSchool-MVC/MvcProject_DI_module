using ModelsLibrary.DtO_Models;
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
            ProductsService service = new ProductsService();
            var product = service.FindByID(id);
            ViewData.Add("id", id);
            ViewData.Add("product", product);

            var photo_service = new ProductPhotoService();
            var photo_list = photo_service.FindById(id).ToList();

            ViewData.Add("photo_list", photo_list);

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