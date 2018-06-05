using ModelsLibrary.DtO_Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Orderinfo
    {
        [Display(Name = "運送方式")]
        [Required]
        public string Transport { get; set; }

        [Display(Name = "付款方式")]
        [Required]
        public string Payment { get; set; }

        [Display(Name = "收件人")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "聯絡電話")]
        [Required]
        public string Phone { get; set; }

        [Display(Name = "地址")]
        [Required]
        public string Address { get; set; }
    }
}