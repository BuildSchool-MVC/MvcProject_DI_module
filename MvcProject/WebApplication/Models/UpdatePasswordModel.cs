using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class UpdatePasswordModel
    {
        [Display(Name = "密碼")]
        [Required]
        [Compare("Password2",ErrorMessage ="密碼驗證錯誤")]
        [RegularExpression(@"^[a-zA-z0-9]{8,}$",ErrorMessage ="密碼不符合標準")]
        public string Password { get; set; }

        [Display(Name = "確認密碼")]
        [Required]
        public string Password2 { get; set; }
    }
}