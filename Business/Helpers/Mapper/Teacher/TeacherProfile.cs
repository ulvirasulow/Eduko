using AutoMapper;
using Business.DTOs.Teacher;

namespace Business.Helpers.Mapper.Teacher;

public class TeacherProfile : Profile
{
    public TeacherProfile()
    {
        CreateMap<UpdateTeacherDTO, Core.Entities.Teacher>();
        CreateMap<CreateTeacherDTO, Core.Entities.Teacher>();
        CreateMap<GetTeacherDTO, Core.Entities.Teacher>().ReverseMap();
    }
}