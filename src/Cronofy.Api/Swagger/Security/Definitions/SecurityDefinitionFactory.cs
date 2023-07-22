using Microsoft.OpenApi.Models;

namespace Cronofy.Api.Swagger.Security.Definitions;

public class SecurityDefinitionFactory
{
    private static List<ISecurityDefinition> SecurityDefinitions => new()
    {
        new JwtBearerSecurityDefinition(),
        new OAuth2AuthenticationCodeSecurityDefinition()
    };

    public ISecurityDefinition Create(SecuritySchemeType securitySchemeType)
    {
        var securityDefinition = SecurityDefinitions.SingleOrDefault(x => x.SecuritySchemeType == securitySchemeType);
        if (securityDefinition is null)
        {
            throw new Exception($"Security definition does not exist for security scheme type {securitySchemeType}.");
        }

        return securityDefinition;
    }
}