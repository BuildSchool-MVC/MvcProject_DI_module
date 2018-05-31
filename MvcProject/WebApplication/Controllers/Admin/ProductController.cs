using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelsLibrary.DtO_Models;
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

        [Route("ProductUpdate/{id}")]
        public ActionResult AdminProductUpdate(int id)
        {
            var productservice = new ProductsService();
            var photoservice = new ProductPhotoService();
            var product = productservice.FindByID(id);
            var items = photoservice.FindById(id);
            var result = new List<ProductPhoto>();

            foreach(var item in items)
            {
                var photo = new ProductPhoto()
                {
                    PhotoID = item.PhotoID,
                    PhotoPath = item.PhotoPath
                };

                result.Add(photo);
            }

            ViewData.Add("list", product);
            ViewData.Add("photo", result);

            return View();
        }
    }
}