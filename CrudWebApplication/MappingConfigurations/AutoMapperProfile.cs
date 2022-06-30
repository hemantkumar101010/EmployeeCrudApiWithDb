using AutoMapper;
using CrudWebApplication.Model;
using EmployeesData.Entities;

namespace CrudWebApplication.MappingConfigurations
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Teacher, TeacherApiModel>();
            CreateMap<ClassRoom, ClassRoomApiModel>();
            CreateMap<TeacherApiModel, Teacher>();
            CreateMap<ClassRoomApiModel, ClassRoom>();
        }
    }
}
