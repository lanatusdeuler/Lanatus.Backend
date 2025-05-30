using ApplicationInterfaces.ExternalServices;
using ApplicationInterfaces.ExternalServices.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebApi.Dtos;

namespace WebApi.Controllers;

/// <summary>
/// チャット関連のコントローラ
/// </summary>
[Route("[controller]")]
[ApiController]
public class ChatsController : ControllerBase
{
    public ChatsController() { }

    [HttpPost("chatRoom/{id:guid}")]
    public async Task<ActionResult<PostUserMessageResponse>> PostUserMessageAsync(
        [FromServices] IChatCompletionService chatCompletionService,
        [FromRoute] Guid id,
        [FromBody] PostUserMessageRequest request
    )
    {
        var response = await chatCompletionService.CreateChatCompletionAsync(new CreateChatCompletionInput(
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
