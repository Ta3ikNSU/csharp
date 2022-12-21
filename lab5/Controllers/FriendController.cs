using lab5.DTO;
using lab5.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab5.Controllers;

[ApiController]
[Route("friend")]
public class FriendController : ControllerBase
{
    private readonly FriendService FriendService;
    private readonly ILogger Logger;

    public FriendController(FriendService friendService, ILogger<FriendController> logger)
    {
        FriendService = friendService;
        Logger = logger;
    }

    [HttpPost("{attempt_number:int}/compare")]
    [ProducesResponseType(typeof(ContenderDTO), 200)]
    public Task<IActionResult> compareContender(
        [FromRoute] int attempt_number,
        [FromBody] PairContenderNameDTO pairContenderNameDto,
        [FromQuery] int? session
    )
    {
        var betterContender =
            FriendService.compareContenders(
                pairContenderNameDto.nameFirstContender!,
                pairContenderNameDto.nameSecondConteder!,
                attempt_number);
        return Task.FromResult<IActionResult>(Ok(new ContenderDTO(betterContender)));
    }
}