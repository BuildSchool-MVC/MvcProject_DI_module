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
            var customerID = user.CustomerID;
            var product = productservice.FindIdByName(ProductList.ProductName, ProductList.Size, ProductList.Color);
            var amount = ProductList.Num;

            ShoppingcartDetailsService.Create(new ShoppingcartDetails() { CustomerID = user.CustomerID, ProductID = product.ProductID, Quantity = amount });
            //AddCart addcart = new AddCart()
            //{
            //    CustomerId = customerID,
            //    ProdictId=product,

            //};
            //ShoppingcartDetailsService.Create()
            
            return RedirectToAction("Product");
        }
    }
}