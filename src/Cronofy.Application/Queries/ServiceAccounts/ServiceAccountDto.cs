namespace Cronofy.Application.Queries.ServiceAccounts;

public record ServiceAccountDto(
    string Id,
    string Domain,
    string AccessToken,
    string RefreshToken);