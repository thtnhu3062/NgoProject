using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models;

public partial class Ourpartner
{
    [Key]
    public int OurpartnerId { get; set; }

    public string? OurpartnerName { get; set; }

    public string? OurpartnerAddress { get; set; }

    public string? OurpartnerLogo { get; set; }

    public string? OurpartnerPhone { get; set; }

    public string? OurpartnerAddressWeb { get; set; }

    public string? OurpartnerMail { get; set; }

  public virtual ICollection<News> News { get; set; } = new List<News>();
}
