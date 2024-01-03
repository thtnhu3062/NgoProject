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
}
