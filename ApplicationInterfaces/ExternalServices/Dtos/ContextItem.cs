using ApplicationInterfaces.ExternalServices.Dtos.Enums;

namespace ApplicationInterfaces.ExternalServices.Dtos;

public record ContextItem
{
    public SourceType SourceType { get; }

    public string Content { get; }

    public ContextItem(
        SourceType sourceType,
        string content
    )
    {
        SourceType = sourceType;
        Content = content;
    }
}
