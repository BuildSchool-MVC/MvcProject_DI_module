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

            return View();
        }

        [Route("Login")]
        [HttpPost]
        public ActionResult Login(loginModel model)
        {
            var service = new CustomerService();
            return View();
        }
    }
}