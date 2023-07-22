using Cronofy.Api.Swagger.Security;
using Microsoft.OpenApi.Models;

namespace Cronofy.Api.Swagger;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomSwaggerGen(
        this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddSwaggerGen(options =>
        {
            options.SupportNonNullableReferenceTypes();

            var oidcAuthority = configuration["Authentication:Schemes:Bearer:Authority"];
            var securitySchemeTypes = new List<SecuritySchemeType> { SecuritySchemeType.Http };
            if (!string.IsNullOrEmpty(oidcAuthority)) securitySchemeTypes.Add(SecuritySchemeType.OAuth2);
            
            options.AddSecurityDefinitions(securitySchemeTypes);
            options.AddSecurityRequirements(securitySchemeTypes);

            var filePath = Path.Combine(AppContext.BaseDirectory, $"{typeof(Program).Assembly.GetName().Name}.xml");
            if (File.Exists(filePath))
            {
                options.IncludeXmlComments(filePath);
            }
        });

        return serviceCollection;
    }
}