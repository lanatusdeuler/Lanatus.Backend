using ApplicationInterfaces.ExternalServices.Dtos.Enums;

namespace ApplicationInterfaces.ExternalServices.Dtos;

public record WebSearchInput
{
    public string Query { get; }

    public int PageNumber { get; } = 1;

    public int PageSize { get; } = 10;

    public string Language { get; } = "ja";

    public string Region { get; } = "JP";

    public WebSearchFileType FilterBy { get; } = WebSearchFileType.All;

    public WebSearchSortOrder SortOrder { get; } = WebSearchSortOrder.Relevance;

    public DateTime? FromDate { get; }

    public Dictionary<string, string>? CustomHeaders { get; }

    public WebSearchInput(
        string query,
        int pageNumber = 1,
        int pageSize = 10,
        string language = "ja",
        string region = "JP",
        WebSearchFileType webSearchFileType = WebSearchFileType.All,
        WebSearchSortOrder webSearchSortOrder = WebSearchSortOrder.Relevance,
        DateTime? fromDate = null,
        Dictionary<string, string>? customHeaders = null
    )
    {

    }
}
