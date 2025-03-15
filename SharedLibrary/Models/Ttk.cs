using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Ttk
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? CategoryId { get; set; }

    public int? VolumeId { get; set; }

    public int? SpotId { get; set; }

    public string? Description { get; set; }

    public string? Ingridients { get; set; }

    public string? HowToCook { get; set; }

    public string? Weight { get; set; }

    public int? ContainerId { get; set; }

    public string? Additives { get; set; }

    public string? Prep { get; set; }

    public string? PhotoPath { get; set; }

    public bool? IsArchive { get; set; }

    public int? MasterCatLvl2Id { get; set; }

    public int? KbjuId { get; set; }

    public virtual CategoriesDim? Category { get; set; }

    public virtual ContainersDim? Container { get; set; }

    public virtual ICollection<KbjuTtk> KbjuTtks { get; set; } = new List<KbjuTtk>();

    public virtual MasterCategoriesDim? MasterCatLvl2 { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();

    public virtual VolumesDim? Volume { get; set; }
}
