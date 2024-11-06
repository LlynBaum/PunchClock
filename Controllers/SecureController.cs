using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace M223PunchclockDotnet.Controllers;

[Route("secure")]
[ApiController]
public class SecureController : ControllerBase
{
    [Authorize]
    [HttpGet("data")]
    public IActionResult GetSecureData()
    {
        return Ok(new { Message = "This is protected data." });
    }
}