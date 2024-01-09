
using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Nhập chính xác địa chỉ email")]
        public string Email { get; set; }
    }
}
