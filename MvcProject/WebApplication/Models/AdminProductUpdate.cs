using ModelsLibrary.DtO_Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class AdminProductUpdate
    {
        
        public int ProductID { get; set; }

        [Display(Name ="產品名稱")]
        [Required]
        [StringLength(50,ErrorMessage ="{0}的長度需介於{2}到{1}",MinimumLength =0)]
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string ProductDetails { get; set; }
        public List<ProductPhoto> ProductPhotoes { get; set; }
    }
}