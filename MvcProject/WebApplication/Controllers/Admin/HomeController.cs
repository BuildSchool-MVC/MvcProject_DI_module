using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers.Admin
{
    [RoutePrefix("Admin")]
    public class HomeController : Controller
    {
        [Route("Index")]
        // GET: Home
        public ActionResult AdminHome()
        {
            return View();
        }
    }
}