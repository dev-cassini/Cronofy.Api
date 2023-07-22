using Microsoft.OpenApi.Models;

namespace Cronofy.Api.Swagger.Security.Definitions;

public static class OAuth2AuthenticationCodeSecurityDefinition
{
    public static (string Name, OpenApiSecurityScheme OpenApiSecurityScheme) Create()
    {
        return (
            "OAuth2 Authentication Code",
            new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Flows = new OpenApiOAuthFlows
                {
                    AuthorizationCode = new OpenApiOAuthFlow
                    {
                        AuthorizationUrl = new Uri(""),
                        TokenUrl = new Uri(""),
                        Scopes = new Dictionary<string, string>()
                    }
                }
            });
    }
}