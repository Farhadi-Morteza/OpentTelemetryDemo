using Microsoft.AspNetCore.Mvc;

namespace WebApiA.Controllers;

[Route("[controller]")]
[ApiController]
public class ProxyController : ControllerBase
{
    private readonly HttpClient _httpClient;

    public ProxyController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("WebApiB");
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
        return Ok($"WebApiA received from WebApiB: {response}");
    }
}
