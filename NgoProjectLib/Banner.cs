using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NgoProjectLib
{
    [Table("tbBanner")]
    public class Banner
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
      public string? Photo {  get; set; }

      
    }
  
}
