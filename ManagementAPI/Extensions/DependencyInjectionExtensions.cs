using HRManagement.Business.Repositories;
using HRManagement.Business.Repositories.impl;
using HRManagement.Business.Services;

namespace ManagementAPI.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddDependencyInjectionServices(this IServiceCollection services){

        services.AddScoped<ITokenRepository, TokenRepository>();

        // Registering services
        services.AddScoped<IAuthService, AuthService>();


        return services;
    }    
}