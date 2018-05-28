using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    [RoutePrefix("Member")]
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult SearchMember()
        {
            return View();
        }

        public ActionResult UpdateMember()
        {
            return View();
        }
    }
}