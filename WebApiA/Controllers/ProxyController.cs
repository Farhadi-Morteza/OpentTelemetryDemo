using Microsoft.AspNetCore.Mvc;

namespace WebApiA.Controllers;

[Route("[controller]")]
[ApiController]
public class ProxyController : ControllerBase
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ProxyController> _logger;

    public ProxyController(IHttpClientFactory httpClientFactory,
        ILogger<ProxyController> logger)
    {
        _httpClient = httpClientFactory.CreateClient("WebApiB");
        _logger = logger;
    }

    [HttpGet("call-WebApiB-GetCoffee")]
    public async Task<IActionResult> CallCoffee()
    {
        var response = await _httpClient.GetStringAsync("/Common/getcoffee");
        return Ok($"WebApiA received from WebApiB: {response}");
    }

    [HttpGet("call-WebApiB-ping")]
    public async Task<IActionResult> CallPing()
    {
        var response = await _httpClient.GetStringAsync("/Common/ping");
        _logger.LogInformation("WebApiB that call currectly!!!!!");
        return Ok($"WebApiA received from WebApiB: {response}");
    }
}
