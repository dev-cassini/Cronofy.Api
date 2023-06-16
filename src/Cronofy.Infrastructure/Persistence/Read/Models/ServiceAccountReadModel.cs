namespace Cronofy.Infrastructure.Persistence.Read.Models;

public record ServiceAccountReadModel(
    string Id,
    string Domain,
    string AccessToken,
    string ProtectedRefreshToken);