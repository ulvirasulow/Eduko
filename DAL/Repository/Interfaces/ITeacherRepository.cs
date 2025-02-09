using Core.Entities;

namespace DAL.Repository.Interfaces;

public interface ITeacherRepository : IRepository<Teacher>
{
    Task<Teacher?> GetTeacherWithCoursesAsync(int id);
    Task<Teacher?> GetTeacherWithBlogsAsync(int id);
    Task<Teacher?> GetTeacherDetailsAsync(int id);
}