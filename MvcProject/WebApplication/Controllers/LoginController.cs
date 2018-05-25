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
    [RoutePrefix("Log")]
    public class LoginController : Controller
    {
        // GET: SignUp
        [Route("Signup")]
        public ActionResult Signup()
        {
            return View();
        }

        [Route("Login")]
        public ActionResult Login()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if(cookie == null)
            {
                ViewBag.IsAuthenticated = false;
                return View();
            }

            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            if(ticket.UserData == "abcdefg")
            {
                ViewBag.IsAuthenticated = true;
                ViewBag.User = ticket.Name;
            }
            else
            {
                ViewBag.IsAuthenticated = false;
            }

            return View();
        }

        [Route("Login")]
        [HttpPost]
        public ActionResult Login(loginModel model)
        {
            var service = new CustomerService();

            var customer_list = service.GetAll().ToList();

            if(customer_list.Any((x) => x.Account == model.User) == false)
            {
                return RedirectToAction("Login");
            }

            if(model.User == customer_list.Find((x) => x.Account == model.User).Account &&
               model.Password == customer_list.Find((x) => x.Account == model.User).Password)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.User, DateTime.Now, DateTime.Now.AddMinutes(30), false, "abcdefg");

                var ticketData = FormsAuthentication.Encrypt(ticket);
                var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketData);
                cookie.Expires = ticket.Expiration; //設定Cookie到期日與憑證同時

                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("loginModel", "Error");
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            cookie.Expires = DateTime.Now;
            Response.Cookies.Add(cookie);

            return RedirectToAction("Login", "Login");
        }
    }
}