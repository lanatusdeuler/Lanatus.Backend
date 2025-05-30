using Microsoft.AspNetCore.Mvc;
using Controllers.Dtos;
using Domain.ExternalServices;
using Domain.ExternalServices.Dtos;

namespace Applications;

/// <summary>
/// チャット関連のコントローラ
/// </summary>
[Route("[controller]")]
[ApiController]
public class ChatsController : ControllerBase
{
    private readonly IChatCompletionService _chatCompletionService;

    public ChatsController(IChatCompletionService chatCompletionService)
        => _chatCompletionService = chatCompletionService;

    [HttpPost("chatRoom/{id:guid}")]
    public async Task<ActionResult<PostUserMessageResponse>> PostUserMessageAsync(
        [FromRoute] Guid id,
        [FromBody] PostUserMessageRequest request
    )
    {
        var response = await _chatCompletionService.CreateChatCompletionAsync(new CreateChatCompletionInput(
            "gpt-4o",
            [new("user", "hello")]
        ));

        // TODO: requestとrouteからInput作る
        // var input = new PostUserMessageInput();

        // // Service呼び出す
        // var output = await _chatService.PostUserMessageAsync(input);

        // // TODO: outputからResponse作る
        // var response = new PostUserMessageResponse();

        return Ok();
    }
}
