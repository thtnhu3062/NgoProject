using System.ComponentModel.DataAnnotations;

namespace NgoProject.ViewModel
{
    public class ViewModelBanner
    {
        [Required]
        public int Id { get; set; }
        [StringLength(250)]
        public IFormFile? Photo { get; set; }

    }
}
