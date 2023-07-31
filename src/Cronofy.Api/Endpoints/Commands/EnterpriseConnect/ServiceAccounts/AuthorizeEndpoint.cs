using Asp.Versioning;
using Cronofy.Api.Authorization.Policies.ServiceAccounts;
using Cronofy.Api.Extensions;
using Cronofy.Application.Commands.ServiceAccounts;
using Cronofy.Domain.Entities.ServiceAccounts;
using MediatR;

namespace Cronofy.Api.Endpoints.Commands.EnterpriseConnect.ServiceAccounts;

public static class AuthorizeEndpoint
{
    public static WebApplication AuthorizeServiceAccountEndpoint(this WebApplication webApplication)
    {
        var apiVersionSet = webApplication.BuildApiVersionSet();

        webApplication.MapPost(
                "/v{version:ApiVersion}/" + $"{Routes.ServiceAccounts}/authorize",
                AuthorizeServiceAccount)
            .WithApiVersionSet(apiVersionSet)
            .HasApiVersion(new ApiVersion(Versions.V1))
            .RequireAuthorization(AuthorizeServiceAccountPolicy.Name)
            .WithTags(nameof(ServiceAccount))
            .Produces(StatusCodes.Status401Unauthorized)
            .Produces(StatusCodes.Status403Forbidden)
            .ProducesValidationProblem();

        return webApplication;
    }

    /// <summary>
    /// Authorizes a <see cref="ServiceAccount"/>.
    /// </summary>
    /// <param name="command">Command.</param>
    /// <param name="mediator">Mediator.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <response code="400">Domain rules failed.</response>
    /// <response code="401">Authentication failed.</response>
    /// <response code="403">Authorization failed.</response>
    private static async Task<IResult> AuthorizeServiceAccount(
        AuthorizeServiceAccountCommand command,
        IMediator mediator,
        CancellationToken cancellationToken)
    {
        await mediator.Send(command, cancellationToken);
        return Results.NoContent();
    }
}