using System.ComponentModel.DataAnnotations;

namespace NgoProject.ViewModel
{
    public class ViewModelOurPartner
    {
        public int OurpartnerId { get; set; }
        [Required]
        public string? OurpartnerName { get; set; }
        [Required]
        public string? OurpartnerAddress { get; set; }
        [Required]
        public IFormFile? OurpartnerLogo { get; set; }
        [Required]
        public string? OurpartnerPhone { get; set; }
        [Required]
        public string? OurpartnerAddressWeb { get; set; }
        [Required]
        public string? OurpartnerMail { get; set; }
    }
}
