namespace Cronofy.Api.Swagger;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomerSwaggerGen(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSwaggerGen(options =>
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, $"{typeof(Program).Assembly.GetName().Name}.xml");
            if (File.Exists(filePath))
            {
                options.IncludeXmlComments(filePath);
            }
        });

        return serviceCollection;
    }
}