using ServiceInterfaces.Chats.Dtos;

namespace ServiceInterfaces.Chats;

/// <summary>
/// チャット関連のサービス
/// </summary>
public interface IChatsService
{
    /// <summary>
    /// メッセージを送信する
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<PostUserMessageResponse> PostUserMessageAsync(PostUserMessageRequest request);
}
