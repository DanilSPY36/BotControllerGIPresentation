using System;
using System.Collections.Generic;

namespace SharedLibrary.Models;

public partial class BranchesDim
{
    public int Id { get; set; }

    public string Branch { get; set; } = null!;

    public virtual ICollection<Operation> Operations { get; set; } = new List<Operation>();
}
