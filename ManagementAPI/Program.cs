using HRManagement.Data.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRManagement API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
// Database configuration
var connectionString = builder.Configuration.GetConnectionString("MyCnn");
builder.Services.AddDbContext<HRManagementDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configure Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true; // Yêu cầu số
    options.Password.RequireLowercase = true; // Yêu cầu chữ thường
    options.Password.RequireUppercase = true; // Yêu cầu chữ hoa
    options.Password.RequireNonAlphanumeric = false; // Không yêu cầu ký tự đặc biệt
    options.Password.RequiredLength = 6; // Độ dài tối thiểu 6 ký tự
})
.AddEntityFrameworkStores<HRManagementDbContext>()
.AddDefaultTokenProviders();

// Configure JWT Authentication
var jwtSettings = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]);
var logger1 = builder.Services.BuildServiceProvider().GetRequiredService<ILogger<Program>>();
logger1.LogInformation("JWT Key length in bytes: {Length}", key.Length);
if (key.Length < 32)
{
    logger1.LogWarning("JWT Key length ({Length} bytes) is less than 32 bytes, which may cause HS256 issues.", key.Length);
}


builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["Issuer"],
        ValidAudience = jwtSettings["Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ClockSkew = TimeSpan.Zero
    };
});


var app = builder.Build();

// Seed Identity data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("Starting identity data seeding...");
        await SeedData.SeedIdentityDataAsync(services);
        logger.LogInformation("Identity data seeding completed successfully.");
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while seeding Identity data.");
    }
}



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();

app.Run();
