using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelsLibrary.Services;
using ModelsLibrary.DtO_Models;

namespace WebApplication.Controllers.Admin
{
    [RoutePrefix("Admin")]
    public class CustomerController : Controller
    {
        [Route("customer")]
        // GET: Customer
        public ActionResult AdminCustomer()
        {
            CustomerService CustomerService = new CustomerService();
            var query = CustomerService.GetAll();
            ViewData.Add("count", query.Count());
            ViewData.Add("list", query);
            return View();
        }
        [Route("Customer/{CustomerID}")]
        // GET: Customer
        public ActionResult UpdateCustomer(int CustomerID)
        {
            CustomerService CustomerService = new CustomerService();
            var user = CustomerService.FindByCustomerId(CustomerID);
            return View(user);
        }
    }
}