using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SharedLibrary.Models;

public partial class VolumesDim
{
    public int Id { get; set; }

    public string? Volume { get; set; }

    public string? Description { get; set; }
    [JsonIgnore]
    public virtual ICollection<KbjuTtk> KbjuTtks { get; set; } = new List<KbjuTtk>();
    [JsonIgnore]
    public virtual ICollection<Ttk> Ttks { get; set; } = new List<Ttk>();
}
