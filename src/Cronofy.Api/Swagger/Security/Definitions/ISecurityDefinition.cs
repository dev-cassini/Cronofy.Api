using Microsoft.OpenApi.Models;

namespace Cronofy.Api.Swagger.Security.Definitions;

public interface ISecurityDefinition
{
    SecuritySchemeType SecuritySchemeType { get; }
    string Name { get; }
    OpenApiSecurityScheme OpenApiSecurityScheme { get; }
    OpenApiSecurityRequirement OpenApiSecurityRequirement { get; }
}