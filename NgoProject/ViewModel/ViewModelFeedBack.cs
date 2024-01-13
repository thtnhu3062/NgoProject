using System.ComponentModel.DataAnnotations;

namespace NgoProject.ViewModel
{
    public class ViewModelFeedBack
    {
        public int FeedbackId { get; set; }
        [StringLength(150)]
        [Required(ErrorMessage = "Name can't blank")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "The email address you entered is not in the correct format.")]
        public string? FeedbackEmail { get; set; }
        [StringLength(11)]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid Phone Number ")]
        [Required(ErrorMessage = "Phone can't be blank")]
        public string? FeedbackPhone { get; set; }
        [Required(ErrorMessage = "Message can't blank")]
        [StringLength(100, ErrorMessage = "Message should be under {1} word")]
        [MinLength(10, ErrorMessage = "Message should be more {1} word")]
        public string? FeedbackMessage { get; set; }
    }
}
