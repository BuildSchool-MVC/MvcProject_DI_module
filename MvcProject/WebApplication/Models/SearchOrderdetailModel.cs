using System;

namespace WebApplication.Models
{
    public class SearchOrderdetailModel
    {
        public string Image { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public decimal UnitPrice { get; set; }
        public int Amount { get; set; }
        public decimal Total { get; set; }
    }
}