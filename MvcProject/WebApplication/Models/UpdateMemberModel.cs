using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class UpdateMemberModel
    {
        [Display(Name = "名稱")]
        [Required]
        public string CustomerName { get; set; }

        [Display(Name = "電話")]
        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }
    }
}