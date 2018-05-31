using ModelsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelsLibrary.DtO_Models;

namespace WebApplication.Controllers
{
    [RoutePrefix("Admin")]
    public class AdminController : Controller
    {   
        //Get:Admin
        [Route("Index")]
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
            decimal total = 0;
            foreach(var item in GetAllOrder)
            {
                total +=servicePro.FindByID(item.ProductID).UnitPrice*item.Quantity;
            }
            ViewBag.Total = Decimal.Round(total);
            return View();
        }

        [Route("Chart")]
        public ActionResult Chart()
        {
            return View();
        }

        [Route("commodity")]
        public ActionResult commodity()
        {
            ProductsService ProductsService = new ProductsService();
            var query = ProductsService.GetAll();
            ViewData.Add("count", query.Count());
            ViewData.Add("list", query);
            return View();
        }

        [Route("customer")]
        public ActionResult customer()
        {
            CustomerService CustomerService = new CustomerService();
            var query = CustomerService.GetAll();
            ViewData.Add("count", query.Count());
            ViewData.Add("list", query);
            return View();
        }

        [Route("orders")]
        public ActionResult orders()
        {
            OrderService OrderService = new OrderService();
            var query = OrderService.GetAll();
            ViewData.Add("count", query.Count());
            ViewData.Add("list", query);
            return View();
        }

        [Route("money")]
        public ActionResult money()
        {
            return View();
        }       
    }
}