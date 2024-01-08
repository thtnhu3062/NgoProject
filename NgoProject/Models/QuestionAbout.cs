using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models
{
    public class QuestionAbout
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Question { get; set; }
        [Required]
        public string? Answer { get; set; }

    }
}
