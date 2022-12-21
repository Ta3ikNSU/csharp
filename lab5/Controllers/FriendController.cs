using lab5.DTO;
using lab5.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab5.Controllers;

[ApiController]
[Route("friend")]
public class FriendController : ControllerBase
{
    private readonly FriendService FriendService;

    public FriendController(FriendService friendService)
    {
        FriendService = friendService;
    }

    [HttpPost("{attempt_number:int}/compare")]
    [ProducesResponseType(typeof(ContenderDTO), 200)]
    public async Task<IActionResult> compareContender(
        [FromRoute] int attempt_number,
        [FromBody] PairContenderNameDTO pairContenderNameDto,
        [FromQuery] int? session
    )
    {
        var betterContender =
            FriendService.compareContenders(
                pairContenderNameDto.nameFirstContender,
                pairContenderNameDto.nameSecondConteder,
                attempt_number);
        return Ok(new ContenderDTO(betterContender));
    }
}