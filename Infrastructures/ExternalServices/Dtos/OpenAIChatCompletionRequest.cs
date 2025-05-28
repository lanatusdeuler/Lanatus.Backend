using System.Text.Json.Serialization;

namespace Infrastructures.ExternalServices.Dtos;

/// <summary>
/// OpenAIのCreateChatCompletionリクエスト
/// </summary>
public record OpenAIChatCompletionRequest
{
    /// <summary>
    /// モデル名
    /// </summary>
    [JsonPropertyName("model")]
    public required string Model { get; init; }

    /// <summary>
    /// 会話履歴
    /// </summary>
    [JsonPropertyName("messages")]
    public required ICollection<OpenAIChatMessage> Messages { get; init; }
}

/// <summary>
/// 会話履歴
/// </summary>
public record OpenAIChatMessage
{
    /// <summary>
    /// メッセージのロール
    /// </summary>
    [JsonPropertyName("role")]
    public required string Role { get; init; }

    /// <summary>
    /// メッセージの内容
    /// </summary>
    [JsonPropertyName("content")]
    public required string Content { get; init; }
}