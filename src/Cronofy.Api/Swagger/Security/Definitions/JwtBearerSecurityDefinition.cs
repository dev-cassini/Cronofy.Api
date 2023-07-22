using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;

namespace Cronofy.Api.Swagger.Security.Definitions;

public static class JwtBearerSecurityDefinition
{
    public static (string Name, OpenApiSecurityScheme OpenApiSecurityScheme) Create()
    {
        return (
            JwtBearerDefaults.AuthenticationScheme, 
            new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT",
                Description = "JWT Authorization header using the Bearer scheme. Example: Bearer JWT_TOKEN_HERE"
            });
    }
}