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
    }
}