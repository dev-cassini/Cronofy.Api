using MediatR;

namespace Cronofy.Application.Commands.ServiceAccounts;

public record AuthorizeServiceAccountCommand(string Code) : IRequest<Unit>;