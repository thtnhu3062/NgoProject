using System;
using System.Collections.Generic;

namespace NgoProject.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string? AdminName { get; set; }

    public string? AdminAvatar { get; set; }

    public string? AdminEmail { get; set; }

    public string? AdminAddress { get; set; }

    public string? AdminPhone { get; set; }
}
