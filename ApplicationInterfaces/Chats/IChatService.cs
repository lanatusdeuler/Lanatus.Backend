using ServiceInterfaces.Chats.Dtos;

namespace ServiceInterfaces.Chats;

/// <summary>
/// チャット関連のサービス
/// </summary>
public interface IChatService
{
    /// <summary>
    /// メッセージを送信する
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    Task<PostUserMessageOutput> PostUserMessageAsync(PostUserMessageInput input);
}
