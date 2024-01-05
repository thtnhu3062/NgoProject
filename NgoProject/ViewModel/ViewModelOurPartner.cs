using System.ComponentModel.DataAnnotations;

namespace NgoProject.ViewModel
{
    public class ViewModelOurPartner
    {
        [Required]
        public int OurpartnerId { get; set; }

        public string? OurpartnerName { get; set; }

        public string? OurpartnerAddress { get; set; }

        public IFormFile? OurpartnerLogo { get; set; }

        public string? OurpartnerPhone { get; set; }

        public string? OurpartnerAddressWeb { get; set; }

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
