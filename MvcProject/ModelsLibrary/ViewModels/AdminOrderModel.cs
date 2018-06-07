using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.ViewModels
{
    public class AdminOrderModel
    {
        public string ProductName { get; set; }
        public string PhotoPath { get; set; }
        public int Quantity { get; set; }
        public decimal Unitprice { get; set; }
        public decimal Total { get; set; }
    }
}
