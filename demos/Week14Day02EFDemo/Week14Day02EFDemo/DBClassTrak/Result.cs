using System;
using System.Collections.Generic;

namespace Week14Day02EFDemo.DBClassTrak;

public partial class Result
{
    public int ClassId { get; set; }

    public int StudentId { get; set; }

    public int ReqId { get; set; }

    public double? Score { get; set; }

    public int? Penalty { get; set; }

    public virtual Class Class { get; set; } = null!;

    public virtual Requirement Req { get; set; } = null!;

    public virtual Student Student { get; set; } = null!;
}
