using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelsLibrary.Services;
using ModelsLibrary.DtO_Models;
using System.Web.Security;

namespace WebApplication.Controllers.Admin
{
    [RoutePrefix("Admin")]
    public class AdminCustomerController : Controller
    {
        [Route("customer")]
        // GET: Customer
        public ActionResult AdminCustomer(string sort)
        {
            CustomerService CustomerService = new CustomerService();         
            var query = CustomerService.GetAllCustomerTotal();

            if (sort != null)
            {
                if (sort == "Id")
                {
                    query=query.OrderBy((x) => x.CustomerID).ToList();
                }
                if (sort == "Account")
                {
                    query=query.OrderBy((x) => x.Account).ToList();
                }
                if (sort == "Cash")
                {
                    query = query.OrderByDescending((x) => x.ShoppingCash).ToList();
                }
                if (sort == "Total")
                {
                    query = query.OrderByDescending((x) => x.Total).ToList();
                }

            }
            ViewData.Add("count", query.Count());
            ViewData.Add("list", query);
            return View();
        }
        [Route("Customer/{CustomerID}")]
        // GET: Customer
        public ActionResult AdminUpdateCustomer(Customer Customer)
        {
            CustomerService CustomerService = new CustomerService();
            var user = CustomerService.FindByCustomerId(Customer.CustomerID);
            return View(user);
        }
        [Route("Customer/{CustomerID}")]
        [HttpPost]
        // GET: Customer
        public ActionResult Customer(Customer Customer)
        {
            CustomerService CustomerService = new CustomerService();
            CustomerService.AdminUpdate(new Customer()
            {
                CustomerID = Customer.CustomerID,
                CustomerName=Customer.CustomerName,
                Email=Customer.Email,
                Phone=Customer.Phone,
                Birthday=Customer.Birthday,
                ShoppingCash=Customer.ShoppingCash
            });
            ViewBag.CustomerID = Customer.CustomerID;
            return RedirectToAction("AdminCustomer");
        }
        [Route("Customer/DeleteCustomer")]
        // GET: Customer
        public ActionResult DeleteCustomer(int CustomerID)
        {
            CustomerService CustomerService = new CustomerService();
            CustomerService.Delete(new Customer { CustomerID = CustomerID });
            return RedirectToAction("AdminCustomer");
        }
        [Route("CustomerAdd")]
        // GET: Customer
        public ActionResult AdminCustomerAdd()
        {
            return View();
        }

        [Route("CustomerAdd")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        // GET: Customer
        public ActionResult AdminCustomerAdd(Customer customer)
        {
            CustomerService CustomerService = new CustomerService();
            CustomerService.Create(new Customer()
            {
                    CustomerName = customer.CustomerName,
                    Birthday = customer.Birthday,
                    Account = customer.Account,
                    Password = customer.Password,                  
                    Phone = customer.Phone,
                    Email =customer.Email,
            });
            return RedirectToAction("AdminCustomer");
        }
    }
}