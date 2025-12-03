using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Week14Day02EFDemo.DBClassTrak;

public partial class DemouserClasstrakContext : DbContext
{
    public DemouserClasstrakContext()
    {
    }

    public DemouserClasstrakContext(DbContextOptions<DemouserClasstrakContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AssignmentType> AssignmentTypes { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<ClassToStudent> ClassToStudents { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Instructor> Instructors { get; set; }

    public virtual DbSet<Requirement> Requirements { get; set; }

    public virtual DbSet<Result> Results { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=data.cnt.sast.ca,24680;Database=demouser_Classtrak;User Id=demoUser;Password=temP2020#;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssignmentType>(entity =>
        {
            entity.HasKey(e => e.AssTypeId);

            entity.ToTable("Assignment_type");

            entity.Property(e => e.AssTypeId).HasColumnName("ass_type_id");
            entity.Property(e => e.AssTypeDesc)
                .HasMaxLength(24)
                .HasColumnName("ass_type_desc");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasIndex(e => e.CourseId, "course_id");

            entity.HasIndex(e => e.InstructorId, "instructor_id");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.ClassDesc)
                .HasMaxLength(32)
                .HasColumnName("class_desc");
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.Days)
                .HasMaxLength(5)
                .HasColumnName("days");
            entity.Property(e => e.InstructorId).HasColumnName("instructor_id");
            entity.Property(e => e.StartDate)
                .HasColumnType("datetime")
                .HasColumnName("start_date");

            entity.HasOne(d => d.Course).WithMany(p => p.Classes)
                .HasForeignKey(d => d.CourseId)
                .HasConstraintName("FK_Classes_Courses");

            entity.HasOne(d => d.Instructor).WithMany(p => p.Classes)
                .HasForeignKey(d => d.InstructorId)
                .HasConstraintName("FK_Classes_Instructors");
        });

        modelBuilder.Entity<ClassToStudent>(entity =>
        {
            entity.ToTable("class_to_student");

            entity.HasIndex(e => e.ClassId, "class_id");

            entity.HasIndex(e => e.StudentId, "student_id");

            entity.Property(e => e.ClassToStudentId).HasColumnName("class_to_student_id");
            entity.Property(e => e.Active).HasColumnName("active");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");

            entity.HasOne(d => d.Class).WithMany(p => p.ClassToStudents)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_class_to_student_Classes");

            entity.HasOne(d => d.Student).WithMany(p => p.ClassToStudents)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_class_to_student_Students");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.CourseId).HasColumnName("course_id");
            entity.Property(e => e.CourseAbbrev)
                .HasMaxLength(10)
                .HasColumnName("course_abbrev");
            entity.Property(e => e.CourseDesc)
                .HasMaxLength(32)
                .HasColumnName("course_desc");
        });

        modelBuilder.Entity<Instructor>(entity =>
        {
            entity.Property(e => e.InstructorId).HasColumnName("instructor_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(24)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(24)
                .HasColumnName("last_name");
        });

        modelBuilder.Entity<Requirement>(entity =>
        {
            entity.HasKey(e => e.ReqId);

            entity.HasIndex(e => e.AssTypeId, "ass_type_id");

            entity.HasIndex(e => e.ClassId, "class_id");

            entity.Property(e => e.ReqId).HasColumnName("req_id");
            entity.Property(e => e.AssDesc)
                .HasMaxLength(48)
                .HasColumnName("ass_desc");
            entity.Property(e => e.AssNumber).HasColumnName("ass_number");
            entity.Property(e => e.AssTypeId).HasColumnName("ass_type_id");
            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.MaxScore).HasColumnName("max_score");
            entity.Property(e => e.TotalWeight).HasColumnName("total_weight");
            entity.Property(e => e.TypeWeight).HasColumnName("type_weight");

            entity.HasOne(d => d.AssType).WithMany(p => p.Requirements)
                .HasForeignKey(d => d.AssTypeId)
                .HasConstraintName("FK_Requirements_Assignment_type");

            entity.HasOne(d => d.Class).WithMany(p => p.Requirements)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_Requirements_Classes");
        });

        modelBuilder.Entity<Result>(entity =>
        {
            entity.HasKey(e => new { e.ClassId, e.StudentId, e.ReqId });

            entity.HasIndex(e => e.ClassId, "class_id");

            entity.HasIndex(e => e.ReqId, "req_id");

            entity.HasIndex(e => e.StudentId, "student_id");

            entity.Property(e => e.ClassId).HasColumnName("class_id");
            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.ReqId).HasColumnName("req_id");
            entity.Property(e => e.Penalty).HasColumnName("penalty");
            entity.Property(e => e.Score).HasColumnName("score");

            entity.HasOne(d => d.Class).WithMany(p => p.Results)
                .HasForeignKey(d => d.ClassId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Results_Classes");

            entity.HasOne(d => d.Req).WithMany(p => p.Results)
                .HasForeignKey(d => d.ReqId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Results_Requirements");

            entity.HasOne(d => d.Student).WithMany(p => p.Results)
                .HasForeignKey(d => d.StudentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Results_Students");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasIndex(e => e.SchoolId, "id").IsUnique();

            entity.Property(e => e.StudentId).HasColumnName("student_id");
            entity.Property(e => e.FirstName)
                .HasMaxLength(24)
                .HasColumnName("first_name");
            entity.Property(e => e.LastName)
                .HasMaxLength(24)
                .HasColumnName("last_name");
            entity.Property(e => e.SchoolId).HasColumnName("school_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
