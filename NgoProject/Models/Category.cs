using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NgoProject.Models;

public partial class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter Name")]
    [DisplayName("Name")]
    [StringLength(maximumLength: 30, MinimumLength = 10, ErrorMessage = "Length must be between 10 to 30")]
    public string? CategoryName { get; set; }
    [Required(ErrorMessage = "Please enter Description")]
    [StringLength(maximumLength: 500, MinimumLength = 100, ErrorMessage = "Length must be between 100 to 300")]
    [DisplayName("Description")]
    public string? CategoryDescription { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
