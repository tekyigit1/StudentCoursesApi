using Microsoft.EntityFrameworkCore;
using StudentCoursesApi.Models;

namespace StudentCoursesApi.Data;

public class SchoolDbContext : DbContext
{
    public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

    public DbSet<Student> Students => Set<Student>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Student>(b =>
        {
            b.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            b.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            b.Property(p => p.Email).HasMaxLength(100).IsRequired();
            b.HasIndex(p => p.Email).IsUnique();
        });

        modelBuilder.Entity<Course>(b =>
        {
            b.Property(p => p.Title).HasMaxLength(100).IsRequired();
        });

        modelBuilder.Entity<Enrollment>(b =>
        {
            b.HasOne(e => e.Student).WithMany(s => s.Enrollments).HasForeignKey(e => e.StudentId);
            b.HasOne(e => e.Course).WithMany(c => c.Enrollments).HasForeignKey(e => e.CourseId);
            b.HasIndex(e => new { e.StudentId, e.CourseId }).IsUnique(); // Aynı öğrenci aynı derse iki kez yazılamasın
        });
    }
}
