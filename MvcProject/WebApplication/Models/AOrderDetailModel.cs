using ModelsLibrary.DtO_Models;
using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public class AOrderDetailModel
    {
        public IEnumerable<ModelsLibrary.ViewModels.AdminOrderModel> Data { get; set; }
        public int OrderId { get; set; }
        public DateTime OrderDay { get; set; }
        public string Transport { get; set; }
        public string Payment { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
}