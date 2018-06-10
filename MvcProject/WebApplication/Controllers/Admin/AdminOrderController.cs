using ModelsLibrary.DtO_Models;
using ModelsLibrary.Services;
using ModelsLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;


namespace WebApplication.Controllers.Admin
{
    [RoutePrefix("Admin")]
    public class AdminOrderController : Controller
    {
        [Route("Order")]
        // GET: Order
        public ActionResult AdminOrder(string Sorting)
        {
            var service = new OrderService();
            var Getall = service.GetAll();

            if (Sorting != null)
            {
                if (Sorting == "OrderID")
                    Getall = Getall.OrderBy((x) => x.OrderID).ToList();
                if (Sorting == "OrderDay")
                    Getall = Getall.OrderBy((x) => x.OrderDay).ToList();
                if (Sorting == "CustomerID")
                    Getall = Getall.OrderBy((x) => x.CustomerID).ToList();
                if (Sorting == "Transport")
                    Getall = Getall.OrderBy((x) => x.Transport).ToList();
                if (Sorting == "Payment")
                    Getall = Getall.OrderBy((x) => x.Payment).ToList();
                if (Sorting == "Finish")
                    Getall = service.ChoiceStatus("訂單完成結案").ToList();
                if (Sorting == "Working")
                    Getall = service.ChoiceStatus("處理中").ToList();
                if (Sorting == "transport")
                    Getall = service.ChoiceStatus("出貨中").ToList();
                if (Sorting == "Ready")
                    Getall = service.ChoiceStatus("已到貨").ToList();
                if (Sorting == "Delete")
                    Getall = service.ChoiceStatus("申請退貨").ToList();
            }
            ViewData.Add("count", Getall.Count());
            ViewData.Add("list", Getall);
            return View();
        }


        [Route("AdminOrderDetail/{id}")]
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
                if(s == _Order.Status)
                {
                    items.Add(new SelectListItem()
                    {
                        Text = s,
                        Value = s
                    });
                }
            }
            foreach (var s in status)
            {
                if (s != _Order.Status)
                {
                    items.Add(new SelectListItem()
                    {
                        Text = s,
                        Value = s
                    });
                }
            }
            ViewBag.status = items;

            return View(model);
        }


        [Route("OrderDetail/{id}")]
        [HttpPost]
        public ActionResult AdminDetail(AOrderDetailModel model)
        {
            var serviceOD = new OrderDetailsService();
            var serviceOR = new OrderService();
            
            var order = new Order()
            {
                OrderID = model.OrderId,
                Transport = model.Transport,
                Payment = model.Payment,
                Status = model.Status,
                Address = model.Address
            };
            serviceOR.Update(order);

            return RedirectToAction("Order", "Admin");
        }

        [Route("Detail")]
        [HttpPost]
        public ActionResult Detail(int OrderID, int ProductID, int Quantity)
        {
            var serviceOD = new OrderDetailsService();
            var serviceOR = new OrderService();

            var orderdetail = new OrderDetails()
            {
                OrderID = OrderID,
                ProductID = ProductID ,
                Quantity = Quantity
            };
            serviceOD.Update(orderdetail);
            return RedirectToAction("Order", "Admin");
        }

    }
}