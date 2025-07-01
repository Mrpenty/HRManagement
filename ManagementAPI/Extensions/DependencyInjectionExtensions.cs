using HRManagement.Business.Repositories;
using HRManagement.Business.Repositories.impl;
using HRManagement.Business.Services.Employee;

namespace ManagementAPI.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services){
        // Registering repositories
        services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
        services.AddScoped<ITokenRepository, TokenRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IAttdendanceRepository, AttdendanceRepository>();
        services.AddScoped<IEmployeeLevelRepository, EmployeeLevelRepository>();
        services.AddScoped<IContractTypeRepository, ContractTypeRepository>();
        services.AddScoped<IPositionRepository, PositionRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        services.AddScoped<IPaySlipRepository, PaySlipRepository>();
        services.AddScoped<ISalaryRepository, SalaryRepository>();
        services.AddScoped<IAuthRepository, AuthRepository>();
        // Registering services
        services.AddScoped<IEmployeeService, EmployeeService>();

        return services;
    }    
}