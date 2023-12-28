using System;
using System.Collections.Generic;

namespace NgoProject.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? CategoryDescription { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
