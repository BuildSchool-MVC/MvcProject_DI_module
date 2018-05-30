﻿using ModelsLibrary.DtO_Models;
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
    [RoutePrefix("shoppingcart")]
    public class ShoppingCartController : Controller
    {
        [Route("detail")]
        // GET: ShoppingCart
        public ActionResult detail()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if(cookie == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            var customer_service = new CustomerService();
            var shopping_service = new ShoppingcartDetailsService();
            var product_service = new ProductsService();
            var photo_service = new ProductPhotoService();

            var user = customer_service.FindByCustomerAccount(ticket.Name);

            var items = shopping_service.FindByCustomer(user.CustomerID);

            var result = new List<ShppingCartModel>();

            foreach(var item in items)
            {
                ShppingCartModel model = new ShppingCartModel();

                model.Image = photo_service.FindById(item.ProductID).First().PhotoPath;
                model.ProductID = item.ProductID;
                model.ProductName = product_service.FindByID(item.ProductID).ProductName;
                model.Color = product_service.FindByID(item.ProductID).Color;
                model.Size = product_service.FindByID(item.ProductID).Size;
                model.Amount = item.Quantity;
                model.UnitPrice = product_service.FindByID(item.ProductID).UnitPrice;
                model.Total = product_service.FindByID(item.ProductID).UnitPrice * item.Quantity;

                result.Add(model);
            }

            ViewData.Add("list", result);

            return View();
        }

        public ActionResult DeleteOne_detail(int ProductID)
        {
            var receiveID = ProductID;

            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            var customer_service = new CustomerService();
            var shopping_service = new ShoppingcartDetailsService();

            var user = customer_service.FindByCustomerAccount(ticket.Name);

            shopping_service.DeleteOneForUser(new ShoppingcartDetails { CustomerID = user.CustomerID, ProductID = receiveID, Quantity = 0 });

            return RedirectToAction("detail");
        }

        [HttpPost]
        public ActionResult GetProducts(string products)
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            var customer_service = new CustomerService();

            var user = customer_service.FindByCustomerAccount(ticket.Name);

            TempData["test"] = products;

            return RedirectToAction("payment");
        }

        [Route("payment")]
        public ActionResult payment()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            var customer_service = new CustomerService();

            var user = customer_service.FindByCustomerAccount(ticket.Name);

            return View();
        }

        [Route("order")]
        // GET: ShoppingCart
        public ActionResult order(string Address)
        {
            return View();
        }
    }
}