namespace Web.Api.Database;

public class Sale
{
    public int Id { get; set; }

    public eCoffeeType CoffeeType { get; set; }

    public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
}
