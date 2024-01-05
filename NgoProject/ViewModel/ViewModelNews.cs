using NgoProject.Models;
using System.ComponentModel.DataAnnotations;
namespace NgoProject.ViewModel
{
    public class ViewModelNews
    {
        [Key]
        public int NewsId { get; set; }

        public string? NewsName { get; set; }

        public IFormFile? NewsImage1 { get; set; }

        public IFormFile? NewsImage2 { get; set; }

        public IFormFile? NewsImage3 { get; set; }

        public string? NewsContent { get; set; }

        public string? NewsDescription { get; set; }

        public int? CategoryId { get; set; }

        public int? OurpartnerId { get; set; }

        public virtual Category? Category { get; set; }

        public virtual ICollection<Donate> Donates { get; set; } = new List<Donate>();

        public virtual Ourpartner? Ourpartner { get; set; }
    }
}
