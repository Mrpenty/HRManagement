using AutoMapper;
using HRManagement.Business.dtos.attendance;
using HRManagement.Business.dtos.contractType;
using HRManagement.Business.dtos.department;
using HRManagement.Business.dtos.employeeLevel;
using HRManagement.Business.dtos.leaveRequest;
using HRManagement.Business.dtos.position;
using HRManagement.Business.dtos.salary;
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
        CreateMap<Attendance, AttendanceDailyStatus>().ReverseMap();
        CreateMap<ContractType, ContractTypeGet>().ReverseMap();
        CreateMap<ContractType, ContractTypeCreate>().ReverseMap();
        CreateMap<EmployeeLevel, EmployeeLevelGet>().ReverseMap();
        CreateMap<EmployeeLevel, EmployeeLevelCreate>().ReverseMap();
        CreateMap<Position, PositionGet>().ReverseMap();
        CreateMap<Position, PositionCreate>().ReverseMap();
        CreateMap<LeaveRequest, LeaveRequestGet>()
    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
        CreateMap<LeaveRequest, LeaveRequestCreate>().ReverseMap();
        CreateMap<Salary, SalaryGet>().ReverseMap();
        CreateMap<Salary, SalaryCreate>().ReverseMap();
    }
}