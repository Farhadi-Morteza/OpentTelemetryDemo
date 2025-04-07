using Microsoft.AspNetCore.Mvc;
using Web.Api.Database;
using WebApiB.Services;

namespace WebApiB.Controllers;

[Route("[controller]")]
[ApiController]
public class CommonController : ControllerBase
{
    private readonly ICoffeeService _coffeeService;

    public CommonController(ICoffeeService coffeeService)
    {
        _coffeeService = coffeeService;
    }

    [HttpGet("ping")]
    public IActionResult Ping()
    {
        System.Threading.Thread.Sleep(2000);
        return Ok("Hello from WebApiB!");
    }

    [HttpGet("getcoffee")]
    public async Task<IActionResult> GetCoffee()
    {
        System.Threading.Thread.Sleep(2000);

        var sales = await _coffeeService.GetSalesAsync();
        return Ok(sales);
    }

    [HttpPost("addcoffee/{coffeeType:int}")]
    public async Task<IActionResult> AddCoffeeAsync(int coffeeType)
    {
        int id = await _coffeeService.Add((eCoffeeType)coffeeType);
        return Ok(id);
    }
}
