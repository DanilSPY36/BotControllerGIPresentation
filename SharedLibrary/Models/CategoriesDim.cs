using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class CategoriesDim
{
    public int Id { get; set; }

    public string Category { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Ttk> Ttks { get; set; } = new List<Ttk>();
}
