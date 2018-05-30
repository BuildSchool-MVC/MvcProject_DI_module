using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    [RoutePrefix("Admin")]
    public class AdminController : Controller
    {   
        [Route("Index")]
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        [Route("Chart")]
        // GET: Admin
        public ActionResult Chart()
        {
            return View();
        }
        [Route("commodity")]
        // GET: Admin
        public ActionResult commodity()
        {
            return View();
        }
        [Route("customer")]
        // GET: Admin
        public ActionResult customer()
        {
            return View();
        }
        [Route("orders")]
        // GET: Admin
        public ActionResult orders()
        {
            return View();
        }
        [Route("money")]
        // GET: Admin
        public ActionResult money()
        {
            return View();
        }
        


    }
}