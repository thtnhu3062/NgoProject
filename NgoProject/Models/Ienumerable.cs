using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models
{
    public class Ienumerable
    {
        [Key]
        public IEnumerable<BannerTable>? Bn1 { get; set; }
        public IEnumerable<BannerTabless>? Bn2 { get; set; }
        public IEnumerable<SendFeedback>? senss { get; set; }
        public IEnumerable<NewsLetter>? newLs {  get; set; } 
    }
}
