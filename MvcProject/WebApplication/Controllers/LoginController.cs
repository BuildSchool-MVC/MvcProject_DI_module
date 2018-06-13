using ModelsLibrary.DtO_Models;
using ModelsLibrary.Repositories;
using ModelsLibrary.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [RoutePrefix("Log")]
    public class LoginController : Controller
    {
        // GET: SignUp
        [Route("Signup")]
        public ActionResult Signup()
        {
            return View();
        }

        [Route("Signup")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup(SignupModel model)
        {
            var Service = new CustomerService();

            var model2 = new Customer()
            {
                CustomerName = model.Name,
                Birthday = model.Birthday,
                Password = model.Password,
                Account = model.Account,
                Phone = model.Phone,
                Email = model.Email,
            };
            Service.Create(model2);
            return View();
        }

        [Route("Login")]
        public ActionResult Login()
        {
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            if (cookie == null)
            {
                ViewBag.IsAuthenticated = false;
                return View();
            }

            var ticket = FormsAuthentication.Decrypt(cookie.Value);

            if (ticket.UserData == "abcdefg")
            {
                ViewBag.IsAuthenticated = true;
                ViewBag.User = ticket.Name;
            }
            else
            {
                ViewBag.IsAuthenticated = false;
            }

            return View();
        }

        [Route("Login")]
        [HttpPost]
        public ActionResult Login(loginModel model)
        {
            var service = new CustomerService();
            var passwordSaltService = new PasswordSaltService();
            var customer_list = service.GetAll().ToList();

            if (customer_list.Any((x) => x.Account == model.User) == false)
            {
                return RedirectToAction("Login");
            };
            if (model.Password == "******")
            {
                return RedirectToAction("Login");
            }

            if (passwordSaltService.PasswordsCheck(service.FindByCustomerAccount(model.User), model.Password))
            {
                FormsAuthentication.SignOut();

                var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

                if (cookie != null)
                {
                    cookie.Expires = DateTime.Now;
                    Response.Cookies.Add(cookie);
                }

                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, model.User, DateTime.Now, DateTime.Now.AddMinutes(30), false, "abcdefg");

                var ticketData = FormsAuthentication.Encrypt(ticket);
                cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketData);
                cookie.Expires = ticket.Expiration; //設定Cookie到期日與憑證同時

                Response.Cookies.Add(cookie);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("loginModel", "Error");
                return RedirectToAction("Login", "Login");
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            cookie.Expires = DateTime.Now;
            Response.Cookies.Add(cookie);

            Response.Redirect("/Log/Login");
            return RedirectToAction("Login", "Login");
        }

        [Route("Auth")]
        public ActionResult Auth()
        {//redirect_uri=重導向 HttpUtility.UrlEncode(重新編碼) scope
            var redirectUrl = "https://accounts.google.com/o/oauth2/v2/auth?"
                + "client_id=" + ConfigurationManager.AppSettings["google:key"]
                + "&redirect_uri=" + HttpUtility.UrlEncode("http://bingshop.azurewebsites.net/Log/google")
                + "&scope=https://www.googleapis.com/auth/userinfo.email https://www.googleapis.com/auth/userinfo.profile"
                + "&response_type=code";

            return Redirect(redirectUrl);
        }

        [Route("google")]
        // GET: Authentication
        public ActionResult Google()
        {
            var customerservice = new CustomerService();
            var code = Request.QueryString["code"];
            var tokenEndpoint = "https://www.googleapis.com/oauth2/v4/token";
            var payload = $"client_id={ConfigurationManager.AppSettings["google:key"]}"
                + $"&client_secret={ConfigurationManager.AppSettings["google:secret"]}"
                + $"&redirect_uri={HttpUtility.UrlEncode("http://bingshop.azurewebsites.net/Log/google")}"
                + $"&code={code}"
                + $"&grant_type=authorization_code";

            var client = new WebClient();
            client.Encoding = Encoding.UTF8;
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");

            var response = client.UploadString(tokenEndpoint, payload);//UploadString(目標網址,資料)
            var o = JObject.Parse(response);
            var accessToken = o.Property("access_token").Value.ToString();
            var profile = client.DownloadString("https://www.googleapis.com/plus/v1/people/me?access_token=" + accessToken);

            var user = JObject.Parse(profile);
            var user_id = user.Values().ToList()[5].ToString();
            var user_email = user.Values().ToList()[3].Values().ToList()[0].First.ToString();
            var user_name = user.Values().ToList()[6].ToString();

            if(customerservice.GetAll().Any((x) => x.Account == user_id) == false)//沒有此帳號
            {
                var user_password = "******";
                customerservice.Create(new Customer { Account = user_id, Email = user_email, CustomerName = user_name,Password=user_password,Phone="未登記",Birthday=new DateTime(2000,01,01) });
            }
            //cookie
            

            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, user_id, DateTime.Now, DateTime.Now.AddMinutes(30), false, "abcdefg");

            var ticketData = FormsAuthentication.Encrypt(ticket);
            cookie = new HttpCookie(FormsAuthentication.FormsCookieName, ticketData);
            cookie.Expires = ticket.Expiration; 

            Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Home");
        }


    }
}