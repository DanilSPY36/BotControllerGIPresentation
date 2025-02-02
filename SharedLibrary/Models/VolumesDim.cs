using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class VolumesDim
{
    public int Id { get; set; }

    public string? Volume { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<KbjuTtk> KbjuTtks { get; set; } = new List<KbjuTtk>();

    public virtual ICollection<Ttk> Ttks { get; set; } = new List<Ttk>();
}
