using lab6.DTO;
using lab6.Services;
using Microsoft.AspNetCore.Mvc;

namespace lab6.Controllers;

[ApiController]
[Route("friend")]
public class FriendController : ControllerBase
{
    private readonly FriendService _friendService;
    private readonly ILogger _logger;

    public FriendController(FriendService friendService, ILogger<FriendController> logger)
    {
        _friendService = friendService;
        _logger = logger;
    }

    [HttpPost("{attemptNumber:int}/compare")]
    [ProducesResponseType(typeof(ContenderDTO), 200)]
    public Task<IActionResult> CompareContender(
        [FromRoute] int attemptNumber,
        [FromBody] PairContenderNameDTO pairContenderNameDto,
        [FromQuery] int? session
    )
    {
        var betterContender =
            _friendService.compareContenders(
                pairContenderNameDto.NameFirstContender!,
                pairContenderNameDto.NameSecondConteder!,
                attemptNumber);
        return Task.FromResult<IActionResult>(Ok(new ContenderDTO(betterContender)));
    }
}