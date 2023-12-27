using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NgoProject.Models
{
    [Table("newsletter")]
    public class NewsLetter
    {
        [Key]
        public int Id { get; set; }
        
        public string? Title { get; set; }

        public string? Content { get; set; }

        public string? Image {  get; set; }

        public DateTime?  DateTime { get; set; }


    }
}
