using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelsLibrary.DtO_Models;
using ModelsLibrary.Services;
using WebApplication.Models;

namespace WebApplication.Controllers.Admin
{
    [RoutePrefix("Admin")]
    public class AdminProductController : Controller
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

        [Route("ProductAdd")]
        [HttpPost]
        public ActionResult AdminProductAdd(AdminProductUpdate model)
        {
            var productservice = new ProductsService();
            var photoservice = new ProductPhotoService();
            var product = new Products()
            {
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice,
                CategoryID = model.CategoryID,
                ProductDetails = model.ProductDetails,
                Size = model.Size,
                Color = model.Color,
                UnitsInStock = model.UnitsInStock,
                Uptime=model.Uptime
            };
            productservice.Create(product);

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
            
            foreach (var item in items)
            {
                var photo = new ProductPhoto()
                {
                    PhotoID = item.PhotoID,
                    PhotoPath = item.PhotoPath
                };

                result.Add(photo);
            }

            var model = new AdminProductUpdate()
            {
                ProductID = id,
                ProductName = product.ProductName,
                UnitPrice = Decimal.Round(product.UnitPrice),
                CategoryID = product.CategoryID,
                ProductDetails = product.ProductDetails,
                Size = product.Size,
                Color = product.Color,
                UnitsInStock = product.UnitsInStock,
                ProductPhotoes=result
            };

            return View(model);
        }

        [Route("ProductUpdate/{id}")]
        [HttpPost]
        public ActionResult AdminProductUpdate(AdminProductUpdate model)
        {
            var productservice = new ProductsService();
            var photoservice = new ProductPhotoService();
            var product = new Products()
            {
                ProductID = model.ProductID,
                ProductName = model.ProductName,
                UnitPrice = model.UnitPrice,
                CategoryID = model.CategoryID,
                ProductDetails = model.ProductDetails,
                Size = model.Size,
                Color = model.Color,
                UnitsInStock = model.UnitsInStock
            };
            productservice.Update(product);


            return View();
        }

        [Route("Product/DeleteProduct")]
        public ActionResult DeleteProduct(int ProductID)
        {
            var productservice = new ProductsService();
            productservice.UpdateDowntime(new Products { ProductID = ProductID, Downtime = DateTime.Now });
            return RedirectToAction("Product", "admin");
        }
    }
}