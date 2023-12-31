﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models;

public partial class Donate
{
    [Key]
    public int DonateId { get; set; }

    public int? NewsId { get; set; }

    public DateTime? DonateDate { get; set; }

    public string? DonateMoney { get; set; }

    public int? UserId { get; set; }

    public virtual News? News { get; set; }

    public virtual User? User { get; set; }
}
