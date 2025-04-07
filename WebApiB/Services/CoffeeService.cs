using Microsoft.EntityFrameworkCore;
using Web.Api.Database;

namespace WebApiB.Services;

public class CoffeeService : ICoffeeService
{
    private readonly CoffeeShopDbContext _context;

    public CoffeeService(CoffeeShopDbContext context)
    {
        _context = context;
    }

    public async Task<int> Add(eCoffeeType coffeeType)
    {
        var sale = new Sale
        {
            CoffeeType = coffeeType
        };
        _context.Sales.Add(sale);
        await _context.SaveChangesAsync();
        return sale.Id;
    }

    public async Task<List<Sale>> GetSalesAsync()
    {
        if (!_context.Sales.Any())
        {
            _context.Sales.Add(new Sale
            {
                CoffeeType = eCoffeeType.Cappuccino
            });
            await _context.SaveChangesAsync();
        }

        System.Threading.Thread.Sleep(1000); // Simulate a delay
        return await _context.Sales.ToListAsync();
    }
}
