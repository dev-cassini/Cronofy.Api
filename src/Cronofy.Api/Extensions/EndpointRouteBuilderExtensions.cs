using Asp.Versioning;
using Asp.Versioning.Builder;

namespace Cronofy.Api.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static ApiVersionSet BuildApiVersionSet(this IEndpointRouteBuilder endpointRouteBuilder)
    {
        return endpointRouteBuilder
            .NewApiVersionSet()
            .HasApiVersion(new ApiVersion(1))
            .ReportApiVersions()
            .Build();
    }
}