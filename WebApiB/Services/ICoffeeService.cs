using Web.Api.Database;

namespace WebApiB.Services;

public interface ICoffeeService
{
    Task<int> Add(eCoffeeType coffeeType);
    Task<List<Sale>> GetSalesAsync();
}
