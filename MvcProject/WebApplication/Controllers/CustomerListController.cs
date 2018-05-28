using ModelsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication.Controllers
{
    public class CustomerListController : Controller
    {
        // GET: CustomerList
        public ActionResult ListMenu()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null)
            {
                ViewBag.Log = false;
            }
            else
            {
                ViewBag.Log = true;
            }

            return PartialView();
        }

        public ActionResult CountCart()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null)
            {
                ViewBag.Count = 0;
            }
            else
            {
                var ticket = FormsAuthentication.Decrypt(cookie.Value);

                var customer_service = new CustomerService();
                var shopping_service = new ShoppingcartDetailsService();

                var user = customer_service.FindByCustomerAccount(ticket.Name);

                var count = shopping_service.FindByCustomer(user.CustomerID).Count();

                ViewBag.Count = count;
            }

            return PartialView();
        }
    }
}