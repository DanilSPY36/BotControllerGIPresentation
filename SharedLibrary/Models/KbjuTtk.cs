using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class KbjuTtk
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Variety { get; set; }

    public float? Proteins { get; set; }

    public float? Fats { get; set; }

    public float? Carbohydrates { get; set; }

    public float? Calories { get; set; }

    public float? Energy { get; set; }

    public float? Caffeine { get; set; }

    public int? VolumeId { get; set; }

    public int? TtkId { get; set; }

    public float? Proteins100 { get; set; }

    public float? Fats100 { get; set; }

    public float? Energy100 { get; set; }

    public float? Caffeine100 { get; set; }

    public float? Carbohydrates100 { get; set; }

    public float? Calories100 { get; set; }

    public virtual Ttk? Ttk { get; set; }

    public virtual VolumesDim? Volume { get; set; }
}
