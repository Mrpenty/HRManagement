using HRManagement.Data.Data;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.Identity;

namespace ManagementAPI.Extensions;

public static class IdentityExtensions
{
    public static IServiceCollection AddIdentityServices(this IServiceCollection services){
            services.AddIdentity<User, IdentityRole<int>>(options => {

                    //Creds Config
                    options.User.RequireUniqueEmail = true;
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequiredLength = 8;

                    //Lock Out Config
                    options.Lockout.AllowedForNewUsers = true;
                    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                    options.Lockout.MaxFailedAccessAttempts = 5;
            }) 
                .AddEntityFrameworkStores<HRManagementDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }    
}