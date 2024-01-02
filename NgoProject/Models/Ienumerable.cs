using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models
{
    public class Ienumerable
    {
        [Key]
        public IEnumerable<Banner>? Bn1 { get; set; }
        public IEnumerable<Bannerss>? Bn2 { get; set; }
     
    }
}
