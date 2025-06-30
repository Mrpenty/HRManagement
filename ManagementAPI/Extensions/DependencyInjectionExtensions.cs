using HRManagement.Business.Repositories;
using HRManagement.Business.Repositories.impl;

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

        return services;
    }    
}