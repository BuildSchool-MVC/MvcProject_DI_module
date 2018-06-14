using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    [RoutePrefix("Admin")]
    public class LinebotController : Controller
    {
        // GET: Linebot
        public ActionResult Index()
        {
            return View();
        }
    }
}