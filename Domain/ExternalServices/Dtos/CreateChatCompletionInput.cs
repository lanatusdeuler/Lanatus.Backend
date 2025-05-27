namespace ServiceInterfaces.Chats.Dtos;

public record CreateChatCompletionInput
{
    public string ModelName { get; }

    public IEnumerable<ChatMessage> Messages { get; }

    public CreateChatCompletionInput(
        string modelName,
        IEnumerable<ChatMessage> messages
    )
    {
        ModelName = modelName;
        Messages = messages;
    }
}

public record ChatMessage
{
    public string Role { get; }

    public string Content { get; }

    public ChatMessage(
        string role,
        string content
    )
    {
        Role = role;
        Content = content;
    }
}
