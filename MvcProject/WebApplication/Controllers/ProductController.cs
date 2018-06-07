using ModelsLibrary.DtO_Models;
using ModelsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
        public ActionResult Index(ProductList ProductList)
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null)
            {
                return RedirectToAction("Login", "Login");
            }
            ProductsService productservice = new ProductsService();
            CustomerService customerservice = new CustomerService();
            ShoppingcartDetailsService ShoppingcartDetailsService = new ShoppingcartDetailsService();
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            var user = customerservice.FindByCustomerAccount(ticket.Name);
            var product = productservice.FindIdByName(ProductList.ProductName, ProductList.Size, ProductList.Color);
            //var stock = productservice.CheckStock(product.ProductID, ProductList.Num);
            if (product.Downtime != null||product.UnitsInStock==0)
            {
                TempData.Add("NoItem", true);
                return RedirectToAction("Product");
            }

                if (ShoppingcartDetailsService.FindByCustomer(user.CustomerID).Any((x) => x.ProductID == product.ProductID))
                {
                    TempData.Add("HasItem", true);
                    return RedirectToAction("Product");
                }

                ShoppingcartDetailsService.Create(new ShoppingcartDetails()
                {
                    CustomerID = user.CustomerID,
                    ProductID = product.ProductID,
                    Quantity = ProductList.Num
                });

                TempData.Add("HasItem", false);
                return RedirectToAction("Product");
            
        }
    }
}