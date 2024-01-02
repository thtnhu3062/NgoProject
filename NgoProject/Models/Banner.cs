using NgoProject.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models;

public partial class Banner
{
    [Key]
    public int IdOne { get; set; }

    public string? TitleOne { get; set; }

    public string? ContentOne { get; set; }

    public string? ImageOne { get; set; }

  
}
