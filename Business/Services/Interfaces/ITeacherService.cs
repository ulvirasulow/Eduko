using Business.DTOs.Teacher;
using Core.Entities;

namespace Business.Services.Interfaces;

public interface ITeacherService : IService<Teacher>
{
    Task<GetTeacherDTO?> GetTeacherWithCoursesAsync(int id);
    Task<GetTeacherDTO?> GetTeacherWithBlogsAsync(int id);
    Task<GetTeacherDTO?> GetTeacherDetailsAsync(int id);
    Task<Teacher> CreateAsync(CreateTeacherDTO dto);
    Task UpdateAsync(int id, UpdateTeacherDTO dto);
}