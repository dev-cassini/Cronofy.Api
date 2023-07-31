using Cronofy.Domain.Enums;

namespace Cronofy.Domain.Entities.Applications;

public sealed class Application
{
    public required string Id { get; init; } = string.Empty;
    public required string DataCenter { get; init; } = string.Empty;
    public required string ClientId { get; init; } = string.Empty;
    public required string ClientSecret { get; init; } = string.Empty;
    public required string ServiceAccountAuthorizationRedirectUri { get; init; } = string.Empty;
    public string SdkIdentifier => Enum.Parse<DataCenter>(DataCenter).ToSdkIdentifier();
}