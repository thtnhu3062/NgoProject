using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NgoProject.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NgoProject.ViewModel
{
    public class ViewModelBanner
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string? Content { get; set; }

        [Required(ErrorMessage = "Image can not be bank")]
        public IFormFile? Image { get; set; }
        public IEnumerable<Banner>? bt { get; set; }

        public IEnumerable<Bannerss>? btss { get; set; }

    }
    public class ViewModelNewLetters
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title can not be bank")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Content can not be bank")]
        public string? Content { get; set; }

        public string? Image { get; set; }

        public DateTime? DateTime { get; set; }
    }

    
}
