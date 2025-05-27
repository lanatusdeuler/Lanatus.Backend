using Microsoft.AspNetCore.Mvc;
using ServiceInterfaces.Chats;
using ServiceInterfaces.Chats.Dtos;
using Controllers.Dtos;
using Microsoft.Extensions.Options;
using Infrastructures.Configures;

namespace Applications;

/// <summary>
/// チャット関連のコントローラ
/// </summary>
[Route("[controller]")]
[ApiController]
public class ChatsController : ControllerBase
{
    private readonly AISettings _aiSettings;

    public ChatsController(IOptions<AISettings> options)
        => _aiSettings = options.Value;

    [HttpPost("chatRoom/{id:guid}")]
    public async Task<ActionResult<PostUserMessageResponse>> PostUserMessageAsync(
        [FromRoute] Guid id,
        [FromBody] PostUserMessageRequest request
    )
    {
        Console.WriteLine(_aiSettings.AICredentials);
        // TODO: requestとrouteからInput作る
        // var input = new PostUserMessageInput();

        // // Service呼び出す
        // var output = await _chatService.PostUserMessageAsync(input);

        // // TODO: outputからResponse作る
        // var response = new PostUserMessageResponse();

        return Ok();
    }
}
