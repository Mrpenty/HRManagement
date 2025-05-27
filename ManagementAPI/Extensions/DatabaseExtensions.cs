using HRManagement.Data.Data;
using Microsoft.EntityFrameworkCore;

namespace ManagementAPI.Extensions
{
    public static class DatabaseExtensions
    {
         public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration){
        services.AddDbContext<HRManagementDbContext>(options =>
            {
                options.UseSqlServer(
                configuration.GetConnectionString("MyCnn"),
                sql => sql.MigrationsAssembly("HRManagement.Data"));
            });
            return services;
    }
    }
}