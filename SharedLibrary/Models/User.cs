using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class User
{
    public string Name { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public long? ChatId { get; set; }

    public long? TgUserId { get; set; }

    public bool? IsAdmin { get; set; }

    public bool? IsAccess { get; set; }

    public int? MainSpotId { get; set; }

    public int? RoleId { get; set; }

    public int Id { get; set; }

    public string Passwordhash { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int? HrPositionId { get; set; }

    public virtual ICollection<Hotcoffee> Hotcoffees { get; set; } = new List<Hotcoffee>();

    public virtual HrPosition? HrPosition { get; set; }

    public virtual SpotsDim? MainSpot { get; set; }

    public virtual RolesDim? Role { get; set; }

    public virtual ICollection<UsersSpot> UsersSpots { get; set; } = new List<UsersSpot>();
}
