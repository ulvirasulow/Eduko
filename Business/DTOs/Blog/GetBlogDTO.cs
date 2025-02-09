using Business.DTOs.Common;
using Business.DTOs.Tag;
using Business.DTOs.Teacher;

namespace Business.DTOs.Blog;

public class GetBlogDTO : BaseIdDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string? ImgUrl { get; set; }
    public DateTime Date { get; set; }
    public string? TeacherOpinion { get; set; }
    public GetTeacherDTO Teacher { get; set; }
    public List<GetTagDTO> Tags { get; set; }
}