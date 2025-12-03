using System;
using System.Collections.Generic;

namespace Week14Day02EFDemo.DBClassTrak;

public partial class Class
{
    public int ClassId { get; set; }

    public string? ClassDesc { get; set; }

    public int? InstructorId { get; set; }

    public int? CourseId { get; set; }

    public DateTime? StartDate { get; set; }

    public string? Days { get; set; }

    public virtual ICollection<ClassToStudent> ClassToStudents { get; } = new List<ClassToStudent>();

    public virtual Course? Course { get; set; }

    public virtual Instructor? Instructor { get; set; }

    public virtual ICollection<Requirement> Requirements { get; } = new List<Requirement>();

    public virtual ICollection<Result> Results { get; } = new List<Result>();
}
