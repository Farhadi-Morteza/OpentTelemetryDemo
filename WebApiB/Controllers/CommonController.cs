using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Api.Database;

namespace WebApiB.Controllers;

[Route("[controller]")]
[ApiController]
public class CommonController : ControllerBase
{
    private readonly CoffeeShopDbContext _context;

    public CommonController(CoffeeShopDbContext context)
    {
        _context = context;
    }

    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok("Hello from WebApiB!");
    }

    [HttpGet("getcoffee")]
    public async Task<IActionResult> GetCoffee()
    {
        if (!_context.Sales.Any())
        {
            _context.Sales.Add(new Sale
            {
                CoffeeType = CoffeeType.Cappuccino
            });
            await _context.SaveChangesAsync();
        }

        var sales = await _context.Sales.ToListAsync();
        return Ok(sales);
    }
}
