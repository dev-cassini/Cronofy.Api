using Cronofy.Api.Swagger.Security;

namespace Cronofy.Api.Swagger;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomSwaggerGen(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(options =>
        {
            options.SupportNonNullableReferenceTypes();
            
            options.AddSecurityDefinitions();

            var filePath = Path.Combine(AppContext.BaseDirectory, $"{typeof(Program).Assembly.GetName().Name}.xml");
            if (File.Exists(filePath))
            {
                options.IncludeXmlComments(filePath);
            }
        });

        return serviceCollection;
    }
}