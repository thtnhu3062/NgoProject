using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models;

public partial class Ourpartner
{
    [Key]
    public int OurpartnerId { get; set; }
    [StringLength(1000)]
    [Required(ErrorMessage = "Name can not blank")]
    public string? OurpartnerName { get; set; }
    [StringLength(3000)]
    [Required(ErrorMessage = "Address can not blank")]

    public string? OurpartnerAddress { get; set; }
    [Required(ErrorMessage = "Logo can not blank")]
    public string? OurpartnerLogo { get; set; }
    [Phone(ErrorMessage = "invalid Phone")]
    [StringLength(11)]
    [DataType(DataType.PhoneNumber)]
    [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile Phone")]
    [Required(ErrorMessage = "Phone can not blank")]
    public string? OurpartnerPhone { get; set; }
    [Url]
    public string? OurpartnerAddressWeb { get; set; }
    [EmailAddress]
    [Required(ErrorMessage = "Mail can not blank")]
    public string? OurpartnerMail { get; set; }

  public virtual ICollection<News> News { get; set; } = new List<News>();
}

