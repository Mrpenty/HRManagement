using HRManagement.Business.Services.HR;
using HRManagement.Data.Data;
using ManagementAPI.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

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
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<LeaveRequestService>();



var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCorsPolicy(builder.Environment);
app.UseSwaggerServices(builder.Environment);
app.Run();