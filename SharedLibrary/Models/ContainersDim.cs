using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SharedLibrary.Models;

public partial class ContainersDim
{
    public int Id { get; set; }

    public string Container { get; set; } = null!;

    public string? Description { get; set; }
    [JsonIgnore]
    public virtual ICollection<Ttk> Ttks { get; set; } = new List<Ttk>();
}
