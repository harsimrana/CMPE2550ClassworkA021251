using System;
using System.Collections.Generic;

namespace Week14Day02EFDemo.DBClassTrak;

public partial class Requirement
{
    public int ReqId { get; set; }

    public int? ClassId { get; set; }

    public int? AssTypeId { get; set; }

    public int? AssNumber { get; set; }

    public string? AssDesc { get; set; }

    public int? MaxScore { get; set; }

    public double? TypeWeight { get; set; }

    public double? TotalWeight { get; set; }

    public virtual AssignmentType? AssType { get; set; }

    public virtual Class? Class { get; set; }

    public virtual ICollection<Result> Results { get; } = new List<Result>();
}
