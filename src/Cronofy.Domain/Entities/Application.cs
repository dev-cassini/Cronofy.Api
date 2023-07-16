using Cronofy.Domain.Enums;

namespace Cronofy.Domain.Entities;

public sealed class Application
{
    public required string Id { get; init; } = string.Empty;
    public required DataCenter DataCenter { get; init; } = DataCenter.Unknown;
    public required string ClientId { get; init; } = string.Empty;
    public required string ClientSecret { get; init; } = string.Empty;
}