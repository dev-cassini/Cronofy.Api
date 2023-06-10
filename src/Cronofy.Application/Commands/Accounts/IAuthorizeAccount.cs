namespace Cronofy.Application.Commands.Accounts;

public interface IAuthorizeAccount
{
    Task ExecuteAsync(string email);
}