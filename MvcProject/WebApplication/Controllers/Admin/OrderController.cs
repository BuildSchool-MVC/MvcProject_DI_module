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
            var serviceOrderDetails = new OrderDetailsService();
            var serviceOrder = new OrderService();
            var servicePhoto = new ProductPhotoService();
            var _OrderDetail = serviceOrderDetails.FindOrderDetail(id);
            var _Order = serviceOrder.FindById(id);

            var model = new AOrderDetailModel();
            model.OrderId = id;
            model.OrderDay = _Order.OrderDay;
            model.Transport = _Order.Transport;
            model.Payment = _Order.Payment;
            model.Address = _Order.Address;
            model.Status = _Order.Status;
            model.Data = _OrderDetail;

            var status = serviceOrder.Status();
            List<SelectListItem> items = new List<SelectListItem>();
            foreach (var s in status)
            {
                items.Add(new SelectListItem()
                {
                    Text = s,
                    Value = s
                });
            }
            ViewBag.status = items;
            
            return View(model);

        }

        [Route("OrderDetail/{id}")]
        [HttpPost]
        public ActionResult AdminOrderDetail(AOrderDetailModel model)
        {
           var serviceOD = new OrderDetailsService();
            var serviceOR = new OrderService();
            /*
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
           */
            return View();
        }

    
    }
}