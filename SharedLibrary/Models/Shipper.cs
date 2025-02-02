using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Shipper
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? FullName { get; set; }

    public string? Inn { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Email { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? Region { get; set; }

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
