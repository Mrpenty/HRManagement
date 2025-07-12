
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
             // Cấu hình để dùng ISO 8601
             options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); // Nếu dùng enum
             options.JsonSerializerOptions.Converters.Add(new DateTimeConverterUsingIso8601());
         })
         .AddOData(options =>
            options.Select()
                   .Filter()
                   .OrderBy()
                   .Expand()
                   .Count()
                   .SetMaxTop(100)
                   .AddRouteComponents("odata", GetEdmModel()));
         return services;
     }
    private static IEdmModel GetEdmModel()
    {
        var builder = new ODataConventionModelBuilder();
        builder.EntitySet<Department>("Department");
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