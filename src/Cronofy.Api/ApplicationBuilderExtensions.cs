using Cronofy.Domain.Common.Validation;
using Microsoft.AspNetCore.Diagnostics;

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

    public static void UseCustomExceptionHandler(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                var exception = context.Features.Get<IExceptionHandlerFeature>()!.Error;
                if (exception is AggregatedBrokenRuleException aggregatedBrokenRuleException)
                {
                    var errors = aggregatedBrokenRuleException
                        .Exceptions
                        .Select(x => x.BrokenRuleSummary)
                        .ToDictionary(x => x.Key, y => new[] { y.Reason });

                    await Results.ValidationProblem(errors).ExecuteAsync(context);
                }
                else
                {
                    await Results.Problem().ExecuteAsync(context);
                }
            });
        });
    }
}