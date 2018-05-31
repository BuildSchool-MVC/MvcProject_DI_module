using ModelsLibrary.Services;
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
            var serviceCus = new CustomerService();
            var serviceOd = new OrderDetailsService();
            var serviceOr = new OrderService();
            var servicePro = new ProductsService();
            ViewBag.CostomerNumber = serviceCus.GetAll().Count();
            ViewBag.OrderNumber = serviceOr.GetAll().Count();
            var ProductNumber = serviceOd.GetAll();
            var Number = 0;
            foreach (var item in ProductNumber)
            {
                Number += item.Quantity;
            }
            ViewBag.ProductNumber = Number;
            var GetAllOrder = serviceOd.GetAll();
            decimal total = 0m;
            foreach(var item in GetAllOrder)
            {
                total += servicePro.FindByID(item.ProductID).UnitPrice * serviceOd.FindById(item.ProductID).Quantity;
            }
            ViewBag.Total = Decimal.Round(total);
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