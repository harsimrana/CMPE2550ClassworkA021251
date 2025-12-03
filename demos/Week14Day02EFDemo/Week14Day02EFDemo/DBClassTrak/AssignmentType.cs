using System;
using System.Collections.Generic;

namespace Week14Day02EFDemo.DBClassTrak;

public partial class AssignmentType
{
    public int AssTypeId { get; set; }

    public string? AssTypeDesc { get; set; }

    public virtual ICollection<Requirement> Requirements { get; } = new List<Requirement>();
}
