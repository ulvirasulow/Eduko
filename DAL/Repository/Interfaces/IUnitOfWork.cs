using Core.Entities;

namespace DAL.Repository.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IBlogRepository BlogRepository { get; }
    ICourseRepository CourseRepository { get; }
    ITeacherRepository TeacherRepository { get; }
    IRepository<Category> CategoryRepository { get; }
    IRepository<Comment> CommentRepository { get; }
    IRepository<Lesson> LessonRepository { get; }
    IRepository<Tag> TagRepository { get; }
    IRepository<Student> StudentRepository { get; }
    
    Task<int> SaveChangesAsync();
    Task BeginTransactionAsync();
    Task CommitAsync();
    Task RollbackAsync();
}