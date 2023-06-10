namespace Cronofy.Application.Queries.ServiceAccount;

public record ServiceAccountDto(
    string Id,
    string Domain,
    string AccessToken,
    string RefreshToken);