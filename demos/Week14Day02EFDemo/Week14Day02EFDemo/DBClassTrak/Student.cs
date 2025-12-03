using System;
using System.Collections.Generic;

namespace Week14Day02EFDemo.DBClassTrak;

public partial class Student
{
    public int StudentId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }

    public int? SchoolId { get; set; }

    public virtual ICollection<ClassToStudent> ClassToStudents { get; } = new List<ClassToStudent>();

    public virtual ICollection<Result> Results { get; } = new List<Result>();
}
