namespace Services.Abstraction;

public interface IProductService
{
    Task SaveAllProductsToFileAsync();
}