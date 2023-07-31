namespace Cronofy.Api.Authorization.Scopes;

public static class Scopes
{
    public static class ServiceAccount
    {
        /// <summary>
        /// Write access to <see cref="Domain.Entities.ServiceAccounts.ServiceAccount"/>.
        /// </summary>
        public const string Write = "cronofy-api:service-account:write";
    }
}