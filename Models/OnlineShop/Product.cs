namespace Models.OnlineShop;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Category { get; set; }
    public bool InStock { get; set; }
    public int Rating { get; set; }
}