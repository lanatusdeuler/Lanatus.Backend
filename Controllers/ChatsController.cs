using Microsoft.AspNetCore.Mvc;
using ServiceInterfaces.Chats;
using ServiceInterfaces.Chats.Dtos;
using Controllers.Dtos;

namespace Controllers;

/// <summary>
/// チャット関連のコントローラ
/// </summary>
[Route("[controller]")]
[ApiController]
public class ChatsController : ControllerBase
{
    private readonly IChatService _chatService;

    public ChatsController(IChatService chatService)
        => _chatService = chatService;

    [HttpPost("chatRoom/{id:guid}")]
    public async Task<ActionResult<PostUserMessageResponse>> PostUserMessageAsync(
        [FromRoute] Guid id,
        [FromBody] PostUserMessageRequest request
    )
    {
        // TODO: requestとrouteからInput作る
        var input = new PostUserMessageInput();

        // Service呼び出す
        var output = await _chatService.PostUserMessageAsync(input);

        // TODO: outputからResponse作る
        var response = new PostUserMessageResponse();

        return Ok(response);
    }
}
