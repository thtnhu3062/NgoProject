using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models
{
    public class Ienumerable
    {
        [Key]
        public IEnumerable<Banner>? Bn1 { get; set; }
        public IEnumerable<Bannerss>? Bn2 { get; set; }
        public IEnumerable<News>? News { get; set; }
        public  IEnumerable<Ourpartner>? Ourpartner { get; set;}
        public IEnumerable<Aboutu>? Abu { get; set; }
        public IEnumerable<QuestionAbout>? questionAbouts { get; set; }

    }
}
