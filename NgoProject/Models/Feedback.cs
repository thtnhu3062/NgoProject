using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models;

public partial class Feedback
{
    [Key]
    public int FeedbackId { get; set; }
    [Required]
    public string? Name { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? FeedbackEmail { get; set; }
    [Required]
    public string? FeedbackPhone { get; set; }
    [Required]
    public string? FeedbackMessage { get; set; }

}
