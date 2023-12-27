using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NgoProject.Models
{
    [Table("banner")]
    public partial class BannerTable
    {
      
        [Key]
        public int IdOne { get; set; }
        
        public string? TitleOne { get; set; }

        public string? ContentOne { get; set; }

        public string? ImageOne { get; set; }
    }
    [Table("bannerss")]
    public partial class BannerTabless
    {

        [Key]
        public int IdTwo { get; set; }

        public string? TitleTwo { get; set; }

        public string? ContentTwo { get; set; }

        public string? ImageTwo { get; set; }

    }

    public partial class SendFeedback
    {
        [Key]
        public string? To { get; set; }

        public string? Subject { get; set; }

        public string? Body { get; set; }
    }
 


}
