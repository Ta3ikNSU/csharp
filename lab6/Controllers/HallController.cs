using lab6.DTO;
using lab6.Services;
using lab6.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab6.Controllers;

[ApiController]
[Route("hall")]
public class HallController : ControllerBase
{
    private readonly AttemptsGenerator _attemptsGenerator;

    private readonly HallService _hallService;
    private readonly ILogger _logger;

    public HallController(HallService hallService, AttemptsGenerator attemptsGenerator, ILogger<HallController> logger)
    {
        _hallService = hallService;
        _attemptsGenerator = attemptsGenerator;
        _logger = logger;
    }

    [HttpPost("{attempt_number:int}/select")]
    public int GetHusbandRating(int attempt_number, int session)
    {
        return _hallService.getHusbandRating(attempt_number);
    }

    [HttpPost("reset")]
    public OkResult reset_attempts(int session)
    {
        _attemptsGenerator.GenerateEnvironment();
        return Ok();
    }

    [HttpPost("{attempt_number:int}/next")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public void GetNextContender(int attempt_number, int session)
    {
        _logger.LogInformation("Hall get reqeust to get next contender. attempt_number : {}", attempt_number);
        _hallService.getNextContender(attempt_number);
    }
}