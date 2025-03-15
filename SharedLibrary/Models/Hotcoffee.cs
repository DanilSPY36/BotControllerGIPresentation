using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Hotcoffee
{
    public int Id { get; set; }

    public string? CoffeeName { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
