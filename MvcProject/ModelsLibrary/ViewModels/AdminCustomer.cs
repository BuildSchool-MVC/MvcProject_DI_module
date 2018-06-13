using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLibrary.ViewModels
{
   public class AdminCustomer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public DateTime? Birthday { get; set; }
        public decimal ShoppingCash { get; set; }
        public string Account { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public decimal Total { get; set; }
    }
}
