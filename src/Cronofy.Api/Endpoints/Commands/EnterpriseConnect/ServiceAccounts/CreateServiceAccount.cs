using Cronofy.Application.Commands.ServiceAccounts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cronofy.Api.Endpoints.Commands.EnterpriseConnect.ServiceAccounts;

public static class CreateServiceAccount
{
    public static void CreateServiceAccountEndpoint(this WebApplication webApplication)
    {
        webApplication.MapPost(
            Routes.ServiceAccounts,
            async (
                [FromBody] CreateServiceAccountCommand command, 
                IMediator mediator, 
                CancellationToken cancellationToken) =>
            {
                await mediator.Send(command, cancellationToken);
                return Results.Ok();
            });
    }
}