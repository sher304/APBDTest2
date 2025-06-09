using Microsoft.AspNetCore.Mvc;
using TestAPBD.DTO;
using TestAPBD.Service;

namespace TestAPBD.Controller;

[ApiController]
[Route("api/track-races")]
public class TrackRacersController : ControllerBase
{

    private readonly TrackRacerInterfcae _service;

    public TrackRacersController(TrackRacerInterfcae service)
    {
        _service = service;
    }

    [HttpPost("participants")]
    public async Task<IActionResult> post([FromBody] TrackRacerDTO trackRacerDTO)
    {
        try
        {
            await _service.post(trackRacerDTO);
            return Ok();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}