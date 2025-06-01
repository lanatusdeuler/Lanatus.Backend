using ApplicationInterfaces.ExternalServices;
using ApplicationInterfaces.ExternalServices.Dtos;
using ApplicationInterfaces.ExternalServices.Dtos.Enums;
using Infrastructures.ExternalServices;
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
    [HttpGet("test")]
    public async Task TestAsync(
        [FromServices] WebSearchServiceFactory factory
    )
    {
        var service = factory.Create(WebSearchEngineType.Google);
        var service2 = factory.Create(WebSearchEngineType.Google);

        var response = await service.SearchAsync(new WebSearchInput
        {
            Query = "ほげーたって何"
        });

        Console.WriteLine(response.EngineType);
    }
}
