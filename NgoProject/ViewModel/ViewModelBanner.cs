using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NgoProject.ViewModel
{
    public class ViewModelBanner
    {
        [Required]
        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Content { get; set; }

        [Required (ErrorMessage ="Image can not be bank")]
        public IFormFile? Image { get; set; }

    }

    
}
