namespace Cronofy.Api;

public static class ApplicationBuilderExtensions
{
    public static void UseSwaggerUI(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("./swagger/v1/swagger.json", "Cronofy API");
            options.RoutePrefix = string.Empty;
        });
    }
}