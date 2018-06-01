using ModelsLibrary.DtO_Models;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class Orderinfo
    {
        public Order Order { get; set; }

        [Display(Name = "Address")]
        [StringLength(50,ErrorMessage = "必須填入地址"),MinLength(1)]
        public string Address { get; set; }
    }
}