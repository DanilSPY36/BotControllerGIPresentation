using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class HrpositionSpot
{
    public int Id { get; set; }

    public int HrPositionId { get; set; }

    public int Spotid { get; set; }

    public virtual HrPosition HrPosition { get; set; } = null!;

    public virtual SpotsDim Spot { get; set; } = null!;
}
