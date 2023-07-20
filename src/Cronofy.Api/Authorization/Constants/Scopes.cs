using Cronofy.Domain.Entities.ServiceAccounts;

namespace Cronofy.Api.Authorization.Constants;

public static class Scopes
{
    /// <summary>
    /// Write access to <see cref="ServiceAccount"/>.
    /// </summary>
    public const string ServiceAccountWrite = "service-account:write";
}