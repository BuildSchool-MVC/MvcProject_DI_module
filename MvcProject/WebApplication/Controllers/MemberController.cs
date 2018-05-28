using ModelsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace WebApplication.Controllers
{
    [RoutePrefix("Member")]
    public class MemberController : Controller
    {


        // GET: Member
        public ActionResult SearchMember()
        {
            var service = new CustomerService();
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            
            var customer = service.FindByCustomerAccount(ticket.Name);
            ViewBag.User = customer.Account;
            ViewBag.Name = customer.CustomerName;
            ViewBag.Email = customer.Email;
            ViewBag.Phone = customer.Phone;
            ViewBag.Cash = customer.ShoppingCash;
            ViewBag.birthday = customer.Birthday.ToString("yyyy-MM-dd");

            return View();
            
        }

        public ActionResult UpdateMember()
        {
            var service = new CustomerService();
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            var customer = service.FindByCustomerAccount(ticket.Name);
            ViewBag.User = customer.Account;
            ViewBag.Name = customer.CustomerName;
            ViewBag.Email = customer.Email;
            ViewBag.Phone = customer.Phone;
            ViewBag.Cash = customer.ShoppingCash;
            ViewBag.birthday = customer.Birthday.ToString("yyyy-MM-dd");

            return View();
        }
    }
}