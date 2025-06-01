namespace ApplicationInterfaces.ExternalServices.Dtos;

public record WebSearchResult
{
    public int Rank { get; }

    public Uri Url { get; }

    public string Title { get; }

    public string Snippet { get; }

    /// <summary>
    /// TODO: 列挙体にする
    /// </summary>
    public string MimeType { get; }

    public Uri? ThumbnailUrl { get; }

    public DateTime? PublishDate { get; }

    public WebSearchResult(
        int rank,
        Uri url,
        string title,
        string snippet,
        string mimeType,
        Uri? thumbnailUrl,
        DateTime? publishDate
    )
    {
        Rank = rank;
        Url = url;
        Title = title;
        Snippet = snippet;
        MimeType = mimeType;
        ThumbnailUrl = thumbnailUrl;
        PublishDate = publishDate;
    }
}
