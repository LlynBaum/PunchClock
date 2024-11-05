using M223PunchclockDotnet.Service;
using Microsoft.AspNetCore.Mvc;

namespace M223PunchclockDotnet.Controllers;

[ApiController]
[Route("statistics")]
public class StatisticsController(EntryService service) : Controller
{
    [HttpGet("time-summaries")]
    public async Task<IActionResult> Get()
    {
        var result = await service.GetTimeSummaries();
        return Ok(result);
    }
}