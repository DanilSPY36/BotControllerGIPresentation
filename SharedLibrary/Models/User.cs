using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public long? ChatId { get; set; }

    public long? TgUserId { get; set; }

    public bool? IsAdmin { get; set; }

    public bool? IsAccess { get; set; }

    public int? SpotId { get; set; }

    public int? RoleId { get; set; }

    public string PasswordHash { get;  set; } = string.Empty;

    public string Email { get;  set; } = string.Empty;

    public virtual RolesDim? Role { get; set; }

    public virtual SpotsDim? Spot { get; set; }

    
}
