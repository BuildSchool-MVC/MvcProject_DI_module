using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class SignupModel
    {
        [Display(Name = "客戶名稱")]
        [StringLength(50,ErrorMessage ="{0}的長度需介於{2}到{1}.",MinimumLength =4)]
        public string Name { get; set; }

        public string Account { get; set; }
        public string Password { get; set; }
        public string Password2 { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
    }
}