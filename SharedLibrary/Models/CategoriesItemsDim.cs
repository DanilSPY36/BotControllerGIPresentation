using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class CategoriesItemsDim
{
    public int Id { get; set; }

    public string Category { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
