using System.ComponentModel.DataAnnotations;

namespace NgoProject.ViewModel
{
    public class ViewModelQuestionAbout
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Question can't blank")]
        [StringLength(100, ErrorMessage = "Question must be under {1} word")]
        [MinLength(10, ErrorMessage = "Question must be more {1} word")]
        public string? Question { get; set; }
        [Required(ErrorMessage = "Answer can't blank")]
        [StringLength(300, ErrorMessage = "Answer must be under {1} word")]
        [MinLength(10, ErrorMessage = "Answer must be more {1} word")]
        public string? Answer { get; set; }
    }
}