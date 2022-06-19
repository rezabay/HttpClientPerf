using Microsoft.AspNetCore.Mvc;

namespace PerfTest.Server.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken token)
    {
        await Task.Delay(1000, token);
        
        return Ok(new
        {
            Date = DateTime.UtcNow
        });
    }
}