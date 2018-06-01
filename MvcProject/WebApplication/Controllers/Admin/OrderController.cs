using ModelsLibrary.Services;
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
            var service = new OrderService();
            var Getall = service.GetAll();
            ViewData.Add("count", Getall.Count());
            ViewData.Add("list", Getall);
            return View();
        }
        [Route("OrderDetail")]
        // GET: Order
        public ActionResult AdminOrderDetail()
        {
            var service = new OrderDetailsService();
            var Getall = service.GetAll();
            //var GetOrderDetaul = service.FindById();
            return View();
        }
    }
}