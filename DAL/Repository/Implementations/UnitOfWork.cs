using Core.Entities;
using DAL.Context;
using DAL.Repository.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace DAL.Repository.Implementations;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    private IDbContextTransaction _transaction;

    private IBlogRepository _blogRepository;
    private ICourseRepository _courseRepository;
    private ITeacherRepository _teacherRepository;
    private IRepository<Category> _categoryRepository;
    private IRepository<Comment> _commentRepository;
    private IRepository<Lesson> _lessonRepository;
    private IRepository<Tag> _tagRepository;
    private IRepository<Student> _studentRepository;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IBlogRepository BlogRepository =>
        _blogRepository ??= new BlogRepository(_context);

    public ICourseRepository CourseRepository =>
        _courseRepository ??= new CourseRepository(_context);

    public ITeacherRepository TeacherRepository =>
        _teacherRepository ??= new TeacherRepository(_context);

    public IRepository<Category> CategoryRepository =>
        _categoryRepository ??= new Repository<Category>(_context);

    public IRepository<Comment> CommentRepository =>
        _commentRepository ??= new Repository<Comment>(_context);

    public IRepository<Lesson> LessonRepository =>
        _lessonRepository ??= new Repository<Lesson>(_context);

    public IRepository<Tag> TagRepository =>
        _tagRepository ??= new Repository<Tag>(_context);

    public IRepository<Student> StudentRepository =>
        _studentRepository ??= new Repository<Student>(_context);

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        try
        {
            await SaveChangesAsync();
            await _transaction.CommitAsync();
        }
        catch
        {
            await RollbackAsync();
            throw;
        }
    }

    public async Task RollbackAsync()
    {
        await _transaction.RollbackAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
        _transaction?.Dispose();
    }
}