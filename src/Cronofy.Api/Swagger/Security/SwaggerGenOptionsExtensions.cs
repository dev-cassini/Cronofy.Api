using Cronofy.Api.Swagger.Security.Definitions;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Cronofy.Api.Swagger.Security;

public static class SwaggerGenOptionsExtensions
{
    public static void AddSecurityDefinitions(this SwaggerGenOptions swaggerGenOptions)
    {
        swaggerGenOptions.AddJwtBearerSecurityDefinition();
        swaggerGenOptions.AddOAuth2AuthenticationCodeSecurityDefinition();
    }

    private static void AddJwtBearerSecurityDefinition(this SwaggerGenOptions swaggerGenOptions)
    {
        var (securityDefinitionName, openApiSecurityScheme) = JwtBearerSecurityDefinition.Create();
        swaggerGenOptions.AddSecurityDefinition(securityDefinitionName, openApiSecurityScheme);
    }

    private static void AddOAuth2AuthenticationCodeSecurityDefinition(this SwaggerGenOptions swaggerGenOptions)
    {
        var (securityDefinitionName, openApiSecurityScheme) = OAuth2AuthenticationCodeSecurityDefinition.Create();
        swaggerGenOptions.AddSecurityDefinition(securityDefinitionName, openApiSecurityScheme);
    }
}