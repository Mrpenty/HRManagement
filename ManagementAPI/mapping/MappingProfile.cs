using AutoMapper;
using HRManagement.Business.dtos.attendance;
using HRManagement.Business.dtos.department;
using HRManagement.Business.dtos.user;
using HRManagement.Data.Entity;


namespace ManagementAPI.mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Department, DepartmentGet>().ReverseMap();
        CreateMap<Department, DepartmentCreate>().ReverseMap();
        CreateMap<User, UserGet>().ReverseMap();
        CreateMap<User, UserUpdate>().ReverseMap();
        CreateMap<Attendance, AttendanceGet>().ReverseMap();
        CreateMap<Attendance, AttendanceCreate>().ReverseMap();
    }
}