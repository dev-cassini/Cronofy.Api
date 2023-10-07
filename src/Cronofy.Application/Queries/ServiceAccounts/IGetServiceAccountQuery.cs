namespace Cronofy.Application.Queries.ServiceAccounts;

public interface IGetServiceAccountQuery
{
    Task<ServiceAccountDto?> ExecuteAsync(string domain);
}