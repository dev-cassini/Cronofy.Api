using Asp.Versioning;
using Cronofy.Api.Authorization.Constants;
using Cronofy.Api.Extensions;
using Cronofy.Application.Commands.ServiceAccounts;
using Cronofy.Domain.Entities.ServiceAccounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cronofy.Api.Endpoints.Commands.EnterpriseConnect.ServiceAccounts;

public static class CreateEndpoint
{
    public static void CreateServiceAccountEndpoint(this WebApplication webApplication)
    {
        var apiVersionSet = webApplication.BuildApiVersionSet();

        webApplication.MapPost(
                "/v{version:ApiVersion}/" + Routes.ServiceAccounts,
                CreateServiceAccount)
            .WithApiVersionSet(apiVersionSet)
            .HasApiVersion(new ApiVersion(Versions.V1))
            .RequireAuthorization(Policies.ServiceAccountWrite)
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status403Forbidden)
            .ProducesValidationProblem();
    }

    /// <summary>
    /// Creates a <see cref="ServiceAccount"/>.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="mediator">Mediator.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <response code="400">Domain rules failed.</response>
    /// <response code="401">Authentication failed.</response>
    /// <response code="403">Authorization failed.</response>
    private static async Task<IResult> CreateServiceAccount(
        CreateServiceAccountCommand command,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        await mediator.Send(command, cancellationToken);
        return Results.NoContent();
    }
}