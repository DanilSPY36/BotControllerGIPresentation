using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class Operation
{
    public int UserId { get; set; }

    public int BranchId { get; set; }

    public int ProductId { get; set; }

    public long Timestamp { get; set; }

    public int Id { get; set; }

    public bool? IsFake { get; set; }

    public bool? IsSearch { get; set; }

    public virtual BranchesDim Branch { get; set; } = null!;

    public virtual Item Product { get; set; } = null!;

    public virtual Ttk Product1 { get; set; } = null!;

    public virtual SingleOrigin ProductNavigation { get; set; } = null!;
}
