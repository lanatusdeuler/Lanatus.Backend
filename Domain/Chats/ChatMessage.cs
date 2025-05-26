namespace Domain.Chats;

public class ChatMessage
{
    public Guid Id { get; }

    public string Role { get; }

    public string Content { get; }

    public ChatMessage(Guid id, string role, string content)
    {
        Id = id;
        Role = role;
        Content = content;
    }
}
