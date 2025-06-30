using AutoMapper;
using HRManagement.Data.Entity;
using ManagementAPI.dtos.attendance;
using ManagementAPI.dtos.department;
using ManagementAPI.dtos.user;

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