using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SpotsDim
{
    public int Id { get; set; }

    public string SpotName { get; set; } = null!;

    public string? Region { get; set; }

    public string? City { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
