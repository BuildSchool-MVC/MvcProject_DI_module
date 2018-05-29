using ModelsLibrary.DtO_Models;
using ModelsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [RoutePrefix("Member")]
    public class MemberController : Controller
    {
        // GET: Member
        [Route("SearchMember")]
        public ActionResult SearchMember()
        {
            var service = new CustomerService();
            var orderservice = new OrderService();
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            
            var customer = service.FindByCustomerAccount(ticket.Name);
            ViewBag.User = customer.Account;
            ViewBag.Name = customer.CustomerName;
            ViewBag.Email = customer.Email;
            ViewBag.Phone = customer.Phone;
            ViewBag.Cash = customer.ShoppingCash;
            ViewBag.birthday = customer.Birthday.ToString("yyyy-MM-dd");

            var orders=orderservice.FindCustomerOrderByCustomerID(customer.CustomerID);

            return View(orders);
            
        }

        [Route("UpdateMember")]
        public ActionResult UpdateMember()
        {
            var service = new CustomerService();
            var passwordSaltService = new PasswordSaltService();
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            var customer = service.FindByCustomerAccount(ticket.Name);
            ViewBag.User = customer.Account;
            ViewBag.Name = customer.CustomerName;
            ViewBag.Email = customer.Email;
            ViewBag.Phone = customer.Phone;
            ViewBag.Cash = customer.ShoppingCash;
            ViewBag.birthday = customer.Birthday.ToString("yyyy-MM-dd");

            return View();
        }

        [Route("UpdateMember")]
        [HttpPost]
        public ActionResult UpdateMember(UpdateMemberModel model)
        {
            var service = new CustomerService();
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            var customer = service.FindByCustomerAccount(ticket.Name);

            try
            {
                var model2 = new Customer()
                {
                    CustomerID = customer.CustomerID,
                    CustomerName = model.CustomerName,
                    Phone = model.Phone,
                    Email = model.Email,
                };
                service.Update(model2);
                return RedirectToAction("SearchMember", "Member");
            }
            catch
            {
                ViewBag.Msg = "不可為空白";
                return View();
            }
        }

        [Route("UpdatePassword")]
        public ActionResult UpdatePassword()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null)
            {
                return RedirectToAction("Login", "Login");
            }

            return View();
        }

        [Route("UpdatePassword")]
        [HttpPost]
        public ActionResult UpdatePassword(UpdatePasswordModel model)
        {
            var service = new CustomerService();
            var passwordSaltService = new PasswordSaltService();
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            var customer = service.FindByCustomerAccount(ticket.Name);

            try
            {
                if (!passwordSaltService.Validate(model.Password))
                {
                    ViewBag.Msg = "密碼不符合規範";
                    return View();
                }
                if (model.Password != model.Password2)
                {
                    ViewBag.Msg = "密碼與確認密碼不符";
                    return View();
                }

                var model2 = new Customer()
                {
                    CustomerID = customer.CustomerID,
                    Password = model.Password
                };
                service.UpdatePassword(model2);

                return RedirectToAction("SearchMember", "Member");
            }
            catch (Exception e)
            {
                ViewBag.Msg = "不可為空白";
                return View();
            }
        }
    }
}