
using HRManagement.Business.dtos.department;
using HRManagement.Business.dtos.leaveRequest;
using HRManagement.Business.dtos.position;
using HRManagement.Business.dtos.user;
using HRManagement.Data.Entity;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ManagementAPI.Extensions;

public static class ControllersExtensions
{
     public static IServiceCollection AddControllersServices(this IServiceCollection services){
        services.AddControllers()
         .AddJsonOptions(options =>
         {
             options.JsonSerializerOptions.PropertyNamingPolicy = null;
             options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
             options.JsonSerializerOptions.Converters.Add(new DateTimeConverterUsingIso8601());
         })
         .AddOData(options =>
            options.Select()
                   .Filter()
                   .OrderBy()
                   .Expand()
                   .Count()
                   .SetMaxTop(100)
                   .AddRouteComponents("api", GetEdmModel()));
         return services;
     }
    private static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder();
        builder.EntitySet<DepartmentGet>("Department");
        builder.EntityType<DepartmentGet>().HasKey(u => u.DepartmentID);
        builder.EntitySet<PositionGet>("Position");
        builder.EntityType<PositionGet>().HasKey(u => u.PositionID);
        builder.EntitySet<UserGet>("User");
        builder.EntityType<UserGet>().HasKey(u => u.Id);
        builder.EntitySet<LeaveRequestGet>("LeaveRequest");
        builder.EntityType<LeaveRequestGet>().HasKey(u => u.LeaveRequestID);
        return builder.GetEdmModel();
    }
    public class DateTimeConverterUsingIso8601 : JsonConverter<DateTime>
    {
        private const string Format = "yyyy-MM-ddTHH:mm:ss";

        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString() ?? "");
        }

        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(Format));
        }
    }
}