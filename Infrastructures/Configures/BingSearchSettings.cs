namespace Infrastructures.Configures;

public class BingSearchSettings
{
    public const string SectionName = "BingSearchSettings";

    public required string BaseUrl { get; init; }

    public required string ApiKey { get; init; }
}
