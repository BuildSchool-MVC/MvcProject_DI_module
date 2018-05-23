using ModelsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    [RoutePrefix("Category")]
    public class CategoryController : Controller
    {
        // GET: Category
        [Route("Clothes")]
        public ActionResult Clothes()
        {
            var service = new CategoriesService();
            var query = service.ClassifyByCategoryName("上衣");
            ViewData.Add("count", query.Count());
            ViewData.Add("list", query);
            return View();
        }
    }
}