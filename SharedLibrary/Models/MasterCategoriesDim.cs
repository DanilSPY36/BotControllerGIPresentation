using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

/// <summary>
/// Категории первого и второго уровня
/// </summary>
public partial class MasterCategoriesDim
{
    public int IdLvl2 { get; set; }

    public string CategoryLvl1 { get; set; } = null!;

    public string CategoryLvl2 { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual ICollection<Ttk> Ttks { get; set; } = new List<Ttk>();
}
