using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class SignupModel
    {
        [Display(Name = "名稱")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "帳戶")]
        [Required]
        public string Account { get; set; }

        [Display(Name = "密碼")]
        [Required]
        [Compare("Password2")]
        [RegularExpression(@"((?=.*\d)(?=.*[a - z]).{8,})")]
        public string Password { get; set; }

        [Display(Name = "確認密碼")]
        [Required]
        public string Password2 { get; set; }


        public string Email { get; set; }

        public DateTime? Birthday { get; set; }


        [Display(Name = "電話")]
        [Required]
        public string Phone { get; set; }
    }
}