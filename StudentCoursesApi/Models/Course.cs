using System.ComponentModel.DataAnnotations;

namespace StudentCoursesApi.Models;

public class Course
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Title { get; set; } = null!;

    [Range(0, 30)]
    public int Credits { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
