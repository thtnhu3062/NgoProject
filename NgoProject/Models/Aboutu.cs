using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models;

public partial class Aboutu
{
    [Key]
    public int AboutusId { get; set; }

    public string? AboutusName { get; set; }

    public string? AboutusImage { get; set; }

    public string? AboutusContent { get; set; }

    public string? AboutusDescription { get; set; }
}
