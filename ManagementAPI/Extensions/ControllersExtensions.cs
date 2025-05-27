
namespace ManagementAPI.Extensions;

public static class ControllersExtensions
{
     public static IServiceCollection AddControllersServices(this IServiceCollection services){
        services.AddControllers();
        // .AddOData(options => options
        //     .Select()
        //     .Filter()
        //     .OrderBy()
        //     .Expand()
        //     .Count()
        //     .SetMaxTop(100)
        //     .AddRouteComponents("api", GetEdmModel()));
        // ;
        return services;
    }

    // private static IEdmModel GetEdmModel()
    // {
    //     var builder = new ODataConventionModelBuilder();
    //     return builder.GetEdmModel();
    // }
}