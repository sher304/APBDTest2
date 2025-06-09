using Microsoft.AspNetCore.Mvc;
using TestAPBD.Service;

namespace TestAPBD.Controller;

[ApiController]
[Route("api/[controller]")]
public class RacersController : ControllerBase
{

    private readonly RacerInterface _racerService;

    public RacersController(RacerInterface racerService)
    {
        this._racerService = racerService;
    }
    
    // [HttpGet]
    // public async Task<IActionResult> Get()
    // {
    //     var result = await _racerService.GetAllRacers();
    //     return Ok(result);
    // }

    [HttpGet("{id}/participations")]
    public async Task<IActionResult> GetParticipations(int id)
    {
        try
        {
            var res = await _racerService.GetRacerById(id);
            return Ok(res);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}
