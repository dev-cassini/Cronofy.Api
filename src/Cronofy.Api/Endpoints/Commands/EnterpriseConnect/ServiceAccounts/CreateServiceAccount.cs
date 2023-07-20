using Asp.Versioning;
using Cronofy.Api.Authorization.Constants;
using Cronofy.Api.Extensions;
using Cronofy.Application.Commands.ServiceAccounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cronofy.Api.Endpoints.Commands.EnterpriseConnect.ServiceAccounts;

public static class CreateServiceAccount
{
    public static void CreateServiceAccountEndpoint(this WebApplication webApplication)
    {
        var apiVersionSet = webApplication.BuildApiVersionSet();

        webApplication.MapPost(
                "/v{version:ApiVersion}/" + Routes.ServiceAccounts,
                async (
                    [FromBody] CreateServiceAccountCommand command,
                    IMediator mediator,
                    CancellationToken cancellationToken) =>
                {
                    await mediator.Send(command, cancellationToken);
                    return Results.Ok();
                })
            .WithApiVersionSet(apiVersionSet)
            .HasApiVersion(new ApiVersion(Versions.V1))
            .RequireAuthorization(Policies.ServiceAccountWrite);
    }
}