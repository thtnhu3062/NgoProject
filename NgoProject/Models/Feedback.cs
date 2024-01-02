using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models;

public partial class Feedback
{
    [Key]
    public int FeedbackId { get; set; }

    public int? UserId { get; set; }

    public string? FeedbackName { get; set; }

    public string? FeedbackEmail { get; set; }

    public string? FeedbackPhone { get; set; }

    public string? FeedbackSubject { get; set; }

    public string? FeedbackMessage { get; set; }

    public virtual User? User { get; set; }
}
