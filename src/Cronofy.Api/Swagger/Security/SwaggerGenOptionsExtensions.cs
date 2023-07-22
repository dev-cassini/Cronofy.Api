using Cronofy.Api.Swagger.Security.Definitions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Cronofy.Api.Swagger.Security;

public static class SwaggerGenOptionsExtensions
{
    public static void AddSecurityDefinitions(
        this SwaggerGenOptions swaggerGenOptions,
        List<SecuritySchemeType> securitySchemeTypes)
    {
        var securityDefinitionFactory = new SecurityDefinitionFactory();
        foreach (var securitySchemeType in securitySchemeTypes)
        {
            var securityDefinition = securityDefinitionFactory.Create(securitySchemeType);
            swaggerGenOptions.AddSecurityDefinition(
                securityDefinition.Name,
                securityDefinition.OpenApiSecurityScheme);
        }
    }
    
    public static void AddSecurityRequirements(
        this SwaggerGenOptions swaggerGenOptions,
        List<SecuritySchemeType> securitySchemeTypes)
    {
        var securityDefinitionFactory = new SecurityDefinitionFactory();
        foreach (var securitySchemeType in securitySchemeTypes)
        {
            var securityDefinition = securityDefinitionFactory.Create(securitySchemeType);
            swaggerGenOptions.AddSecurityRequirement(securityDefinition.OpenApiSecurityRequirement);
        }
    }
}