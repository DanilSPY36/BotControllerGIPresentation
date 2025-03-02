using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SharedLibrary.Models;

public partial class HrPosition
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<HrpositionSpot> HrpositionSpots { get; set; } = new List<HrpositionSpot>();
    [JsonIgnore]
    public virtual ICollection<User> Users { get; set; } = new List<User>();

}
