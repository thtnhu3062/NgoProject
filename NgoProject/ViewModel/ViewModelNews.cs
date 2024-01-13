using NgoProject.Models;
using System.ComponentModel.DataAnnotations;
namespace NgoProject.ViewModel
{
    public class ViewModelNews
    {
        [Key]
        public int NewsId { get; set; }
        [Required(ErrorMessage = "Please entered name")]
        [Display(Name = "Name")]
        [StringLength(200)]
        public string? NewsName { get; set; }

        [Required(ErrorMessage = "Do not leave the image blank")]
        [Display(Name = "Image")]
        public IFormFile? NewsImage1 { get; set; }
        [Required(ErrorMessage = "Please entered content")]
        [Display(Name = "Content")]
        [StringLength(1000)]
        public string? NewsContent { get; set; }
        [Required(ErrorMessage = "Please entered description")]
        [StringLength(400)]
        [Display(Name = "Description")]
        public string? NewsDescription { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        [Required]
        [Display(Name = "Our Partner")]
        public int? OurpartnerId { get; set; }

    }
}
