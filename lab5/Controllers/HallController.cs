using lab5.DTO;
using lab5.Services;
using lab5.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace lab5.Controllers;

[ApiController]
[Route("hall")]
public class HallController : ControllerBase
{

    private HallService HallService;
    private AttemptsGenerator AttemptsGenerator;
    
    public HallController(HallService hallService, AttemptsGenerator attemptsGenerator)
    {
        HallService = hallService;
        AttemptsGenerator = attemptsGenerator;
    }

    [HttpPost("{attempt_number:int}/select")]
    public Int32 getHusbandRating(int attempt_number, int session)
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
    public ContenderDTO getNextContender(int attempt_number, int session)
    {
        return new ContenderDTO(HallService.getNextContender(attempt_number));
    }
}
