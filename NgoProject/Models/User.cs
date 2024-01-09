using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models;

public partial class User
{
    [Key]
    public int UserId { get; set; }
    [Required]
    [StringLength(15)]
    public string? UserName { get; set; }
    [Required]
    public string? UserEmail { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public string? UserPassword { get; set; }

    public string? UserAddress { get; set; }

    public string? UserAvatar { get; set; }
    [Required]
    public string? UserPhone { get; set; }

    public virtual ICollection<Donate> Donates { get; set; } = new List<Donate>();

    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
}
