using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class ProductList
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public string PhotoPath { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string ProductDetails { get; set; }
        public int Num { get; set; }

    }
}