using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SingleOriginTypesDim
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public virtual ICollection<SingleOrigin> SingleOrigins { get; set; } = new List<SingleOrigin>();
}
