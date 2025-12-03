using System;
using System.Collections.Generic;

namespace Week14Day02EFDemo.DBClassTrak;

public partial class Instructor
{
    public int InstructorId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public virtual ICollection<Class> Classes { get; } = new List<Class>();
}
