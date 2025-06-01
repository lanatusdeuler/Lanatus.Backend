namespace Infrastructures.Configures;

public class GoogleSearchSettings
{
    public const string SectionName = "GoogleSearchSettings";

    public required string BaseUrl { get; init; }

    public required string ApiKey { get; init; }

    public required string SearchEngineId { get; init; }
}
