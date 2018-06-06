using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelsLibrary.ViewModels
{
    public class ProductList
    {
        public List<int> ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public List<string> PhotoPath { get; set; }
        public List<string> Size { get; set; }
        public List<string> Color { get; set; }
        public string ProductDetails { get; set; }
        public DateTime? Downtime { get; set; }
    }
}