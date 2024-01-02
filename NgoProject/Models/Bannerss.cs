using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models;

public partial class Bannerss
{
    [Key]
    public int IdTwo { get; set; }

    public string? TitleTwo { get; set; }

    public string? ContentTwo { get; set; }

    public string? ImageTwo { get; set; }
}
