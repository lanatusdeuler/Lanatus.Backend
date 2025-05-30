namespace Domain.ExternalServices.Dtos;

public record CreateChatCompletionOutput
{
    public string Role { get; }

    public string Answer { get; }

    public CreateChatCompletionOutput(
        string role,
        string answer
    )
    {
        Role = role;
        Answer = answer;
    }
}
