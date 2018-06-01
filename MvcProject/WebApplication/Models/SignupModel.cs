using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class SignupModel
    {
        [Display(Name = "姓名")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "帳戶")]
        [Required]
        public string Account { get; set; }
        [Display(Name = "密碼")]
        [Required]
        public string Password { get; set; }
        [Display(Name = "確認密碼")]
        [Required]
        public string Password2 { get; set; }
        [Display(Name = "信箱")]
        [Required]
        public string Email { get; set; }
        [Display(Name = "生日")]
        [Required]
        public DateTime Birthday { get; set; }
        [Display(Name = "電話")]
        [Required]
        public string Phone { get; set; }
    }
}