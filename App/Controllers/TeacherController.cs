using Business.DTOs.Teacher;
using Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

public class TeacherController : Controller
{
    private readonly ITeacherService _teacherService;
    private readonly ILogger<TeacherController> _logger;

    public TeacherController(ITeacherService teacherService, ILogger<TeacherController> logger)
    {
        _teacherService = teacherService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> GetTeacherWithCoursesAsync(int id)
    {
        var teacher = await _teacherService.GetTeacherWithCoursesAsync(id);
        return Ok(teacher);
    }

    [HttpGet]
    public async Task<IActionResult> GetTeacherWithBlogsAsync(int id)
    {
        var teacher = await _teacherService.GetTeacherWithBlogsAsync(id);
        return Ok(teacher);
    }

    [HttpGet]
    public async Task<IActionResult> GetTeacherDetailsAsync(int id)
    {
        var teacher = await _teacherService.GetTeacherDetailsAsync(id);
        return Ok(teacher);
    }

    [HttpPost]
    public async Task<IActionResult> CreateTeacherAsync([FromBody] CreateTeacherDTO dto)
    {
        var teacher = await _teacherService.CreateAsync(dto);
        return CreatedAtAction(nameof(GetTeacherDetailsAsync), new { id = teacher.Id }, teacher);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTeacherAsync(int id, [FromBody] UpdateTeacherDTO dto)
    {
        await _teacherService.UpdateAsync(id, dto);
        return NoContent();
    }
}