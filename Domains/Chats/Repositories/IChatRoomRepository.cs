namespace Domain.Chats.Repositories;

/// <summary>
/// 会話部屋のリポジトリ
/// </summary>
public interface IChatRoomRepository
{
    /// <summary>
    /// 会話部屋のIdを指定して取得する
    /// </summary>
    /// <param name="chatRoomId"></param>
    /// <returns></returns>
    Task<ChatRoom> GetByIdAsync(Guid chatRoomId);

    /// <summary>
    /// 変更を保存する
    /// </summary>
    /// <param name="chatRoomId"></param>
    /// <returns></returns>
    Task SaveAsync(ChatRoom chatRoom);

    /// <summary>
    /// 会話部屋を削除する
    /// </summary>
    /// <param name="chatRoomId"></param>
    /// <returns></returns>
    Task DeleteAsync(Guid chatRoomId);
}
