using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    [RoutePrefix("shoppingcart")]
    public class ShoppingCartController : Controller
    {
        [Route("detail")]
        // GET: ShoppingCart
        public ActionResult detail()
        {
            return View();
        }

        [Route("payment")]
        public ActionResult payment()
        {
            return View();
        }

        [Route("order")]
        // GET: ShoppingCart
        public ActionResult order()
        {
            return View();
        }
    }
}