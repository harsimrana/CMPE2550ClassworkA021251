using System;
using System.Collections.Generic;

namespace Week14Day02EFDemo.DBClassTrak;

public partial class Course
{
    public int CourseId { get; set; }

    public string? CourseAbbrev { get; set; }

    public string? CourseDesc { get; set; }

    public virtual ICollection<Class> Classes { get; } = new List<Class>();
}
