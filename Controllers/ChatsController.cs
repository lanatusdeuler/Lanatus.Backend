using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ServiceInterfaces.Chats;
using ServiceInterfaces.Chats.Dtos;

namespace Controllers;

/// <summary>
/// チャット関連のコントローラ
/// </summary>
[Route("[controller]")]
[ApiController]
public class ChatsController : ControllerBase
{
    private readonly IChatsService _chatsService;

    public ChatsController(IChatsService chatsService)
        => _chatsService = chatsService;

    [HttpPost("chatRoom/{id:guid}")]
    public async Task<ActionResult<PostUserMessageResponse>> PostUserMessageAsync(PostUserMessageRequest request)
    {
        var result = await _chatsService.PostUserMessageAsync(request);
        return Ok(result);
    }
}
