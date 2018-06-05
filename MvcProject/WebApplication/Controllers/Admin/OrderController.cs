using ModelsLibrary.DtO_Models;
using ModelsLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

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
        [Route("OrderDetail/{id}")]
        // GET: Order
        public ActionResult AdminOrderDetail(int id)
        {
            var serviceOD = new OrderDetailsService();
            var serviceOR = new OrderService();
            var servicePro = new ProductsService();
            var servicePic = new ProductPhotoService();
            var OrderDetail = serviceOD.FindById(id);
            var Order = serviceOR.FindById(id);
            var OrderDetailList = new List<AOrderDetailModel>();

            foreach (var item in OrderDetail)
            {
                var Product = servicePro.FindByID(item.ProductID);
                var _Photo = servicePic.FindPicById(item.ProductID);

                var model = new AOrderDetailModel()
                {
                    OrderId = id,
                    OrderDay = Order.OrderDay,
                    Transport = Order.Transport,
                    Payment = Order.Payment,
                    Address = Order.Address,
                    Status = Order.Status,
                    PhotoPath = _Photo.PhotoPath,
                    ProductName = Product.ProductName,
                    Quantity = item.Quantity,
                    UnitPrice = Product.UnitPrice,
                    Total = Decimal.Round(item.Quantity * Product.UnitPrice)

                };
                OrderDetailList.Add(model);
            }
            ViewData.Add("list", OrderDetailList);
            ViewData.Add("count", OrderDetailList.Count());
            return View();
        }

        [Route("OrderDetail/{id}")]
        [HttpPost]
        public ActionResult AdminOrderDetail(AOrderDetailModel model)
        {
            var serviceOD = new OrderDetailsService();
            var serviceOR = new OrderService();
            var servicePro = new ProductsService();
            var order = new Order()
            {
                OrderID = model.OrderId,
                Transport = model.Transport,
                Payment = model.Payment,
                Status = model.Status,
                Address = model.Address
            };
            serviceOR.Update(order);

            var orderdetail = new OrderDetails()
            {
                OrderID = model.OrderId,
                ProductID =servicePro.FindByName2(model.ProductName).ProductID,
                Quantity = model.Quantity
            };
            serviceOD.Update(orderdetail);

            return View();
        }
    }
}