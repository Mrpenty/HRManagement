using HRManagement.Business.Repositories;
using HRManagement.Business.Repositories.impl;
using HRManagement.Business.Services.Auth;
using HRManagement.Business.Services.Employee;
using Microsoft.AspNetCore.Hosting;

namespace ManagementAPI.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services){
        // Registering repositories

        services.AddScoped<ITokenRepository, TokenRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        // Registering services
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IEmployeeService, EmployeeService>();

       


        return services;
    }    
}