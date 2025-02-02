using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

/// <summary>
/// Линейка зерна (create, innovate, basse)
/// </summary>
public partial class BeanCategoriesDim
{
    public int Id { get; set; }

    public string BeanCategory { get; set; } = null!;

    public virtual ICollection<SingleOrigin> SingleOrigins { get; set; } = new List<SingleOrigin>();
}
