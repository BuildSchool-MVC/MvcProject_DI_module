using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers.Admin
{
    [RoutePrefix("Admin")]
    public class OrderController : Controller
    {
        [Route("Order")]
        // GET: Order
        public ActionResult AdminOrder()
        {
            return View();
        }
        [Route("OrderDetail")]
        // GET: Order
        public ActionResult AdminOrderDetail()
        {
            return View();
        }
    }
}