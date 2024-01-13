using System.ComponentModel.DataAnnotations;

namespace NgoProject.ViewModel
{
    public class ViewModelAbout
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title can't blank")]
        [StringLength(200, ErrorMessage = "Title must be under {1} word")]
        [MinLength(10, ErrorMessage = "Title must be more {1} word")]
        public string? Title { get; set; }
        [Required(ErrorMessage = "Content can't blank")]
        [StringLength(250, ErrorMessage = "Content must be under {1} word")]
        [MinLength(10, ErrorMessage = "Content must be more {1} word")]
        public string? Content { get; set; }
        [Required(ErrorMessage = "File can't blank")]
        public IFormFile? Photo { get; set; }
    }
}