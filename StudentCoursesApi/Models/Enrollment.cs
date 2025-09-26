﻿namespace StudentCoursesApi.Models;

public class Enrollment
{
    public int Id { get; set; }

    public int StudentId { get; set; }
    public Student Student { get; set; } = null!;

    public int CourseId { get; set; }
    public Course Course { get; set; } = null!;

    public decimal? Grade { get; set; } // 0-100 (opsiyonel)
}
