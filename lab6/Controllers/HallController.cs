using lab6.DTO;
using lab6.Services;
using lab6.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab6.Controllers;

[ApiController]
[Route("hall")]
public class HallController : ControllerBase
{
    private readonly AttemptsGenerator AttemptsGenerator;

    private readonly HallService HallService;
    private readonly ILogger Logger;

    public HallController(HallService hallService, AttemptsGenerator attemptsGenerator, ILogger<HallController> logger)
    {
        HallService = hallService;
        AttemptsGenerator = attemptsGenerator;
        Logger = logger;
    }

    [HttpPost("{attempt_number:int}/select")]
    public int getHusbandRating(int attempt_number, int session)
    {
        return HallService.getHusbandRating(attempt_number);
    }

    [HttpPost("reset")]
    public OkResult reset_attempts(int session)
    {
        AttemptsGenerator.GenerateEnvironment();
        return Ok();
    }

    [HttpPost("{attempt_number:int}/next")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public void getNextContender(int attempt_number, int session)
    {
        Logger.LogInformation("Hall get reqeust to get next contender. attempt_number : {}", attempt_number);
        HallService.getNextContender(attempt_number);
    }
}