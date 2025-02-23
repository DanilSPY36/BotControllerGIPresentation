using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class SpotsDim
{
    public int Id { get; set; }

    public string SpotName { get; set; } = null!;

    public string? Region { get; set; }

    public string? City { get; set; }
    public string? Inn { get; set; }
    public string? FullAdress { get; set; }

    public virtual ICollection<HrpositionSpot> HrpositionSpots { get; set; } = new List<HrpositionSpot>();

    public virtual ICollection<User> Users { get; set; } = new List<User>();

    public virtual ICollection<UsersSpot> UsersSpots { get; set; } = new List<UsersSpot>();
}
