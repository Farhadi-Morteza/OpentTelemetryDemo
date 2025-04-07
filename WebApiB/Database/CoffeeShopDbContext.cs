using Microsoft.EntityFrameworkCore;

namespace Web.Api.Database;

public class CoffeeShopDbContext : DbContext
{
    public CoffeeShopDbContext(DbContextOptions<CoffeeShopDbContext> options)
        : base(options)
    {
    }

    public DbSet<Sale> Sales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost;Database=WebApiB;User Id=sa;Password=Baran972;TrustServerCertificate=True;")
            .EnableSensitiveDataLogging()
            .LogTo(Console.WriteLine, LogLevel.Information); // Log SQL queries to console for debugging purposes
    }
}
