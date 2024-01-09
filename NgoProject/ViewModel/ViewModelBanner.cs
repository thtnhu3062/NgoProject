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

        [StringLength(20)]

        public string? Title { get; set; }
        [StringLength(30)]

        public string? Content { get; set; }
        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        public IFormFile? Image { get; set; }

    }
  

    
}
