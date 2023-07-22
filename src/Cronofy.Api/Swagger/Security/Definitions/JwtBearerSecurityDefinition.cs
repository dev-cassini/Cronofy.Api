using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace Cronofy.Api.Swagger.Security.Definitions;

public class JwtBearerSecurityDefinition : ISecurityDefinition
{
    public SecuritySchemeType SecuritySchemeType => SecuritySchemeType.Http;
    public string Name => JwtBearerDefaults.AuthenticationScheme;

    public OpenApiSecurityScheme OpenApiSecurityScheme => new()
    {
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        BearerFormat = "JWT",
        Description = "JWT Authorization header using the Bearer scheme."
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