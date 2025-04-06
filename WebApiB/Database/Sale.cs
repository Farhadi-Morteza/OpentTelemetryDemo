namespace Web.Api.Database;

public class Sale
{
    public int Id { get; set; }

    public CoffeeType CoffeeType { get; set; }

    public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
}
