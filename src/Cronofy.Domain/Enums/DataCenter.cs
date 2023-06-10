namespace Cronofy.Domain.Enums;

public enum DataCenter
{
    Unknown = 0,
    Australia = 1,
    Canada = 2,
    Germany = 3,
    Singapore = 4,
    UnitedKingdom = 5,
    Usa = 6
}

public static class DataCenterExtensions
{
    public static string ToSdkIdentifier(this DataCenter dataCenter)
        => dataCenter switch
        {
            DataCenter.Australia => "au",
            DataCenter.Canada => "ca",
            DataCenter.Germany => "de",
            DataCenter.Singapore => "sg",
            DataCenter.UnitedKingdom => "uk",
            DataCenter.Usa => "us",
            _ => throw new Exception()
        };
}