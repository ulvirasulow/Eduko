using Core.Entities;
using DAL.Context;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Implementations;

public class TeacherRepository : Repository<Teacher>, ITeacherRepository
{
    private readonly AppDbContext _context;

    public TeacherRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<Teacher?> GetTeacherWithCoursesAsync(int id)
    {
        return await _context.Teachers
            .Include(t => t.Courses)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Teacher?> GetTeacherWithBlogsAsync(int id)
    {
        return await _context.Teachers
            .Include(t => t.Blogs)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<Teacher?> GetTeacherDetailsAsync(int id)
    {
        return await _context.Teachers
            .Include(t => t.Courses)
            .Include(t => t.Blogs)
            .FirstOrDefaultAsync(t => t.Id == id);
    }
}