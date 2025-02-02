using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Item
{
    public int Id { get; set; }

    public int ShipperId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? Composition { get; set; }

    public int? Weight { get; set; }

    public float? Proteins { get; set; }

    public float? Fats { get; set; }

    public float? Carbohydrates { get; set; }

    public float? Calories { get; set; }

    public float? Energy { get; set; }

    public bool? Vegan { get; set; }

    public bool? SugarFree { get; set; }

    public bool? GlutenFree { get; set; }

    public bool? DairyFree { get; set; }

    public bool? SoyaFree { get; set; }

    public bool? Natural100 { get; set; }

    public string? StorageCond { get; set; }

    public string? ExpirationDate { get; set; }

    public string? Allergens { get; set; }

    public int CategoryId { get; set; }

    public string? PhotoPath { get; set; }

    public bool? IsArchive { get; set; }

    public int? MasterCatLvl2Id { get; set; }

    public virtual CategoriesItemsDim Category { get; set; } = null!;

    public virtual MasterCategoriesDim? MasterCatLvl2 { get; set; }

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();

    public virtual Shipper Shipper { get; set; } = null!;
}
