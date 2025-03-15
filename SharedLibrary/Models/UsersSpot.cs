using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharedLibrary.Models;

public partial class UsersSpot
{
    public int Id { get; set; }

    public int UserId { get; set; }

    public int Spotid { get; set; }

    public virtual SpotsDim? Spot { get; set; } = null!;

    public virtual User? User { get; set; } = null!;
    [NotMapped]
    public virtual bool isSelect { get; set; } = false;
}
