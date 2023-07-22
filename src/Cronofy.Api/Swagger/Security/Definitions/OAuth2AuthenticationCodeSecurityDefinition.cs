using Cronofy.Api.Authorization.Constants;
using Microsoft.OpenApi.Models;

namespace Cronofy.Api.Swagger.Security.Definitions;

public class OAuth2AuthenticationCodeSecurityDefinition : ISecurityDefinition
{
    public SecuritySchemeType SecuritySchemeType => SecuritySchemeType.OAuth2;
    public string Name => "OAuth2 Authentication Code";

    public OpenApiSecurityScheme OpenApiSecurityScheme => new()
    {
        Type = SecuritySchemeType.OAuth2,
        Flows = new OpenApiOAuthFlows
        {
            AuthorizationCode = new OpenApiOAuthFlow
            {
                AuthorizationUrl = new Uri("TODO"),
                TokenUrl = new Uri("TODO"),
                Scopes = new Dictionary<string, string>
                {
                    { Scopes.ServiceAccountWrite, "Write access to Service Accounts." }
                }
            }
        }
    };
    
    public OpenApiSecurityRequirement OpenApiSecurityRequirement => new()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = Name,
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    };
}