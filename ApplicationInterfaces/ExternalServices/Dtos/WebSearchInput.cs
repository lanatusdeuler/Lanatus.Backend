using ApplicationInterfaces.ExternalServices.Dtos.Enums;

namespace ApplicationInterfaces.ExternalServices.Dtos;

public record WebSearchInput
{
    public required string Query { get; init; }

    public int PageNumber { get; } = 1;

    public int PageSize { get; } = 10;

    public string Language { get; } = "ja";

    public string Region { get; } = "JP";

    public WebSearchFileType FilterBy { get; } = WebSearchFileType.All;

    public WebSearchSortOrder SortOrder { get; } = WebSearchSortOrder.Relevance;

    public DateTime? FromDate { get; }

    public Dictionary<string, string>? CustomHeaders { get; }
}
