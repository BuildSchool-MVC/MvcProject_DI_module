using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelsLibrary.Services;

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
    }
}