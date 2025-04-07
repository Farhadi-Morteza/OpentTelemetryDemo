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

    [HttpPost("call-WebApiB-AddCoffee/{coffeeType:int}")]
    public async Task<IActionResult> AddCoffee(int coffeeType)
    {
        try
        {
            // Using PostAsync instead of GetStringAsync since this is a [HttpPost] endpoint
            var response = await _httpClient.PostAsync($"/Common/addcoffee/{coffeeType}", null);

            // Ensure the request was successful
            response.EnsureSuccessStatusCode();

            // Read the response content
            var responseContent = await response.Content.ReadAsStringAsync();

            return Ok($"WebApiA called WebApiB to add new coffee. WebApiB response: {responseContent}");
        }
        catch (HttpRequestException ex)
        {
            // Log the error (you should inject ILogger in your controller)
            return StatusCode(StatusCodes.Status502BadGateway,
                $"Failed to call WebApiB: {ex.Message}");
        }
    }

    [HttpGet("call-WebApiB-ping")]
    public async Task<IActionResult> CallPing()
    {
        var response = await _httpClient.GetStringAsync("/Common/ping");
        _logger.LogInformation("WebApiB that call currectly!!!!!");
        return Ok($"WebApiA received from WebApiB: {response}");
    }
}
