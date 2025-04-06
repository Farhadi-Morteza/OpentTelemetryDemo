using Microsoft.EntityFrameworkCore;

namespace Web.Api.Database;

public class CoffeeShopDbContext : DbContext
{
    public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options)
        : base(options)
    {
    }

    public DbSet<Sale> Sales { get; set; }
}
