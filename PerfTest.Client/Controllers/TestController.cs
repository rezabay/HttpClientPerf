using Microsoft.AspNetCore.Mvc;

namespace PerfTest.Client.Controllers;

[ApiController]
[Route("api/test")]
public class TestController : ControllerBase
{
    private readonly IHttpClientFactory _clientFactory;

    public TestController(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var client = _clientFactory.CreateClient("TestClient");
        var result = await client.GetStringAsync("https://localhost:7091/api/test");

        return Ok(new
        {
            Data = result
        });
    }
}