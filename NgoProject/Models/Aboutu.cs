using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models;

public partial class Aboutu
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Content { get; set; }
    [Required]
    public string? Image { get; set; }
}
