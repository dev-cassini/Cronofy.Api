using Cronofy.Domain.Entities.ServiceAccounts;

namespace Cronofy.Api.Authorization.Constants;

public static class Policies
{
    /// <summary>
    /// Authorization policy required to perform write operations on <see cref="ServiceAccount"/>.
    /// </summary>
    public const string ServiceAccountWrite = "service-account-write";
}