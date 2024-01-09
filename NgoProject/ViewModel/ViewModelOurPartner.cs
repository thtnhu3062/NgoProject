using System.ComponentModel.DataAnnotations;

namespace NgoProject.ViewModel
{
    public class ViewModelOurPartner
    {
        [Required]
        public int OurpartnerId { get; set; }
        [StringLength(1000)]
        [Required(ErrorMessage = "Name can not blank")]
        public string? OurpartnerName { get; set; }
        [StringLength(3000)]
        [Required(ErrorMessage = "Address can not blank")]
        public string? OurpartnerAddress { get; set; }
        [Required(ErrorMessage = "Logo can not blank")]
        public IFormFile? OurpartnerLogo { get; set; }
        [Phone(ErrorMessage = "invalid Phone")]
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile Phone")]
        [Required(ErrorMessage = "Phone can not blank")]
        public string? OurpartnerPhone { get; set; }
        [Url]
        public string? OurpartnerAddressWeb { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Mail can not blank")]
        public string? OurpartnerMail { get; set; }
    }
   public class ViewModelRegister
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public IFormFile? UserAvatar { get; set; }
        [Required]
        public string? UserEmail { get; set; }
        [Required]
        public string? UserPassword { get; set; }
        [Required]
        public string? UserAddress { get; set; }
        [Required]
        public string? UserPhone { get; set; }
    }
}
