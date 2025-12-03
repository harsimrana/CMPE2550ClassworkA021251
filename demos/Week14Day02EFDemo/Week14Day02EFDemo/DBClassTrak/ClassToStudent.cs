using System;
using System.Collections.Generic;

namespace Week14Day02EFDemo.DBClassTrak;

public partial class ClassToStudent
{
    public int ClassToStudentId { get; set; }

    public int? ClassId { get; set; }

    public int? StudentId { get; set; }

    public bool? Active { get; set; }

    public virtual Class? Class { get; set; }

    public virtual Student? Student { get; set; }
}
