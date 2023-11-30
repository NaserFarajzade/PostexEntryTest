namespace Models.OnlineShop;

public class Order
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
}