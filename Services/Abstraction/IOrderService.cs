namespace Services.Abstraction;

public interface IOrderService
{
    Task SaveAllOrdersToFileAsync();
}