namespace Cronofy.Application.Queries.ServiceAccount;

public interface IGetServiceAccountQuery
{
    Task<ServiceAccountDto?> ExecuteAsync(string domain);
}