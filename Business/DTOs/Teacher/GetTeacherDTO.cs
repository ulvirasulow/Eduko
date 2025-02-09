using Business.DTOs.Blog;
using Business.DTOs.Common;
using Business.DTOs.Course;

namespace Business.DTOs.Teacher;

public class GetTeacherDTO : BaseIdDTO
{
    public string Fullname { get; set; }
    public string? ProfileImgUrl { get; set; }
    public string Position { get; set; }
    public int Experience { get; set; }
    public string? PersonalExperience { get; set; }
    public string? Address { get; set; }
    public string Email { get; set; }
    public string? Phone { get; set; }
    public string? CertificatesUrl { get; set; }
    public string? Education { get; set; }
    public string? Achievements { get; set; }
    public string? Skills { get; set; }
    public string? FacebookUrl { get; set; }
    public string? TwitterUrl { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? InstagramUrl { get; set; }
    public List<GetCourseDTO> Courses { get; set; }
    public List<GetBlogDTO> Blogs { get; set; }
}