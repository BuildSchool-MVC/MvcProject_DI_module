using ModelsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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