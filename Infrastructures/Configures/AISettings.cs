namespace Infrastructures.Configures;

public class AISettings
{
    public const string SectionName = "AISettings";

    public required AICredential AICredentials { get; init; }
}

public class AICredential
{
    public required Uri EndPoint { get; init; }

    public required string Credential { get; init; }
}