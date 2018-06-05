using ModelsLibrary.DtO_Models;
using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public class AOrderDetailModel
    {
        public int OrderId { get; set; }
        public DateTime OrderDay { get; set; }
        public string Transport { get; set; }
        public string Payment { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
        public string PhotoPath { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
    }
}