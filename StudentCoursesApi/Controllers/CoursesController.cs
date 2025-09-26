using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentCoursesApi.Data;
using StudentCoursesApi.Models;

namespace StudentCoursesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CoursesController : ControllerBase
{
    private readonly SchoolDbContext _db;
    public CoursesController(SchoolDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        Ok(await _db.Courses.AsNoTracking().ToListAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var c = await _db.Courses.FindAsync(id);
        return c is null ? NotFound() : Ok(c);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Course c)
    {
        _db.Add(c);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = c.Id }, c);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Course c)
    {
        if (id != c.Id) return BadRequest();
        var exists = await _db.Courses.AnyAsync(x   => x.Id == id);
        if (!exists) return NotFound();
        _db.Entry(c).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var c = await _db.Courses.FindAsync(id);
        if (c is null) return NotFound();
        _db.Remove(c);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
