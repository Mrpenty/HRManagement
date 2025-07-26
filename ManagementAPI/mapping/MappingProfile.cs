using AutoMapper;
using HRManagement.Business.dtos.attendance;
using HRManagement.Business.dtos.contractType;
using HRManagement.Business.dtos.department;
using HRManagement.Business.dtos.employeeLevel;
using HRManagement.Business.dtos.leaveRequest;
using HRManagement.Business.dtos.Payslip;
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
        CreateMap<User, UserGet>()
            .ForMember(dest => dest.DepartmentName,
                opt => opt.MapFrom(src => src.Department == null ? null : src.Department.DepartmentName))
            .ForMember(dest => dest.EmployeeLevelName,
                opt => opt.MapFrom(src => src.EmployeeLevel == null ? null : src.EmployeeLevel.EmployeeLevelName))
            .ForMember(dest => dest.ContractTypeName,
                opt => opt.MapFrom(src => src.ContractType == null ? null : src.ContractType.ContractTypeName))
            .ForMember(dest => dest.PositionName,
                opt => opt.MapFrom(src => src.Position == null ? null : src.Position.PositionName))
            .ReverseMap();
        CreateMap<UserUpdate, User>()
            .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
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
        CreateMap<Salary, SalaryGet>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));
        CreateMap<Salary, SalaryCreate>().ReverseMap();
        CreateMap<Payslip, PaySlipGet>()
            .ForMember(dest => dest.UserName,
                       opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
            .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.User.Department != null ? src.User.Department.DepartmentName : null))
            .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.User.Position != null ? src.User.Position.PositionName : null))
            .ForMember(dest => dest.BaseSalary,
                       opt => opt.MapFrom(src => src.Salary.BaseSalary))
            .ForMember(dest => dest.Allowances,
                       opt => opt.MapFrom(src => src.Salary.Allowances))
            .ForMember(dest => dest.Bonus,
                       opt => opt.MapFrom(src => src.Salary.Bonus))
            .ForMember(dest => dest.Deduction,
                       opt => opt.MapFrom(src => src.Salary.Deduction))
            .ForMember(dest => dest.Tax,
                       opt => opt.MapFrom(src => src.Salary.Tax))
            .ForMember(dest => dest.NetSalary,
                       opt => opt.MapFrom(src => src.Salary.NetSalary));
        CreateMap<Payslip, PaySlipCreate>().ReverseMap();
    }
}