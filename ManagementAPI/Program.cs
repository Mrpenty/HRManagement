using HRManagement.Business.Services.HR;
using ManagementAPI.Extensions;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);


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

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCorsPolicy(builder.Environment);
app.UseSwaggerServices(builder.Environment);
app.Run();