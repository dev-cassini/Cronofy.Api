using Asp.Versioning;

namespace Cronofy.Api;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomApiVersioning(this IServiceCollection serviceCollection)
    {
        var apiVersioningBuilder = serviceCollection.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ReportApiVersions = true;
            options.ApiVersionReader = new UrlSegmentApiVersionReader();
        });

        apiVersioningBuilder.AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VVV";
            options.SubstituteApiVersionInUrl = true;
        });

        return serviceCollection;
    }
}