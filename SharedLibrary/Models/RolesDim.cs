using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class RolesDim
{
    public int Id { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
