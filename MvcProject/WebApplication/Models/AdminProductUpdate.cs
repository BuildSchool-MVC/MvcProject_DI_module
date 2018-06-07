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

        [Display(Name = "上架時間")]
        [Required]
        public DateTime Uptime { get; set; }

        [Display(Name ="產品名稱")]
        [Required]
        public string ProductName { get; set; }

        [Display(Name = "類別")]
        [Required]
        public int CategoryID { get; set; }

        [Display(Name = "價格")]
        [Required]
        public decimal UnitPrice { get; set; }

        [Display(Name = "庫存")]
        [Range(0,32767,ErrorMessage ="{0}必須大於{1}")]
        [Required]
        public int UnitsInStock { get; set; }

        [Display(Name = "尺寸")]
        [Required]
        public string Size { get; set; }

        [Display(Name = "顏色")]
        [Required]
        public string Color { get; set; }

        [Display(Name = "產品敘述")]
        [Required]
        public string ProductDetails { get; set; }
    }
}