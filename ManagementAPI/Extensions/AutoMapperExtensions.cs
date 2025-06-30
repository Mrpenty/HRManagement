using AutoMapper;
using ManagementAPI.mapping;

namespace ManagementAPI.Extensions;

public static class AutoMapperExtensions
{
    public static IServiceCollection AddAutoMapperServices(this IServiceCollection services){
        services.AddAutoMapper(typeof(MappingProfile));
        return services;
    }
}