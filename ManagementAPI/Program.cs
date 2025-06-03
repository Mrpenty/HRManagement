using HRManagement.Business.Services.HR;

using HRManagement.Data.Data;
using ManagementAPI.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Builder;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HRManagementDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn")));

// Configure services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerServices();
builder.Services.AddControllersServices();
builder.Services.AddDatabaseServices(builder.Configuration);
builder.Services.AddIdentityServices();
builder.Services.AddAuthenticationServices(builder.Configuration);
builder.Services.AddDependencyInjectionServices();
builder.Services.AddCorsServices(builder.Configuration, builder.Environment);
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<LeaveRequestService>();




builder.Services.AddRazorPages();

var app = builder.Build();



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();
app.UseCorsPolicy(builder.Environment);
app.UseSwaggerServices(builder.Environment);
app.Run();