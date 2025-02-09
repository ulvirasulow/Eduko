using AutoMapper;
using Business.DTOs.Teacher;
using Business.Helpers.Exceptions.Common;
using Business.Services.Interfaces;
using Core.Entities;
using DAL.Repository.Implementations;
using DAL.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace Business.Services.Implementations;

public class TeacherService : Service<Teacher>, ITeacherService
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IMapper _mapper;
    private readonly ILogger<TeacherService> _logger;

    private readonly List<string> _allowedExtensions = new List<string> { ".jpg", ".jpeg", ".png", ".gif" };

    public TeacherService(
        ITeacherRepository teacherRepository,
        IMapper mapper,
        ILogger<TeacherService> logger)
        : base(teacherRepository, logger)
    {
        _teacherRepository = teacherRepository;
        _mapper = mapper;
        _logger = logger;
    }

    public async Task<Teacher> CreateAsync(CreateTeacherDTO dto)
    {
        try
        {
            if (dto == null)
                throw new ValidationException("Teacher data cannot be null");

            if (await _teacherRepository.IsExistAsync(t => t.Email == dto.Email))
                throw new BusinessException("Teacher with this email already exists");

            if (!string.IsNullOrEmpty(dto.ProfileImgUrl))
            {
                var fileExtension = Path.GetExtension(dto.ProfileImgUrl).ToLower();
                if (!_allowedExtensions.Contains(fileExtension))
                    throw new ValidationException(
                        $"Invalid file format. Allowed formats: {string.Join(", ", _allowedExtensions)}");
            }

            var teacher = _mapper.Map<Teacher>(dto);
            await _teacherRepository.CreateAsync(teacher);
            await _teacherRepository.SaveChangesAsync();

            _logger.LogInformation("Teacher created successfully with ID {Id}", teacher.Id);
            return teacher;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while creating teacher");
            throw;
        }
    }

    public async Task UpdateAsync(int id, UpdateTeacherDTO dto)
    {
        try
        {
            if (dto == null)
                throw new ValidationException("Teacher update data cannot be null");

            var teacher = await _teacherRepository.GetByIdAsync(id);
            if (teacher == null)
                throw new NotFoundException($"Teacher with ID {id} not found");

            if (await _teacherRepository.IsExistAsync(t => t.Email == dto.Email && t.Id != id))
                throw new BusinessException("Teacher with this email already exists");

            if (!string.IsNullOrEmpty(dto.ProfileImgUrl))
            {
                var fileExtension = Path.GetExtension(dto.ProfileImgUrl).ToLower();
                if (!_allowedExtensions.Contains(fileExtension))
                    throw new ValidationException(
                        $"Invalid file format. Allowed formats: {string.Join(", ", _allowedExtensions)}");
            }

            _mapper.Map(dto, teacher);
            await _teacherRepository.UpdateAsync(teacher);
            await _teacherRepository.SaveChangesAsync();

            _logger.LogInformation("Teacher updated successfully with ID {Id}", id);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while updating teacher with ID {Id}", id);
            throw;
        }
    }

    public async Task<GetTeacherDTO?> GetTeacherWithCoursesAsync(int id)
    {
        try
        {
            var teacher = await _teacherRepository.GetTeacherWithCoursesAsync(id);
            if (teacher == null)
                throw new NotFoundException($"Teacher with ID {id} not found");

            return _mapper.Map<GetTeacherDTO>(teacher);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting teacher with courses for ID {Id}", id);
            throw;
        }
    }

    public async Task<GetTeacherDTO?> GetTeacherWithBlogsAsync(int id)
    {
        try
        {
            var teacher = await _teacherRepository.GetTeacherWithBlogsAsync(id);
            if (teacher == null)
                throw new NotFoundException($"Teacher with ID {id} not found");

            return _mapper.Map<GetTeacherDTO>(teacher);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting teacher with blogs for ID {Id}", id);
            throw;
        }
    }

    public async Task<GetTeacherDTO?> GetTeacherDetailsAsync(int id)
    {
        try
        {
            var teacher = await _teacherRepository.GetTeacherDetailsAsync(id);
            if (teacher == null)
                throw new NotFoundException($"Teacher with ID {id} not found");

            return _mapper.Map<GetTeacherDTO>(teacher);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting teacher details for ID {Id}", id);
            throw;
        }
    }
}