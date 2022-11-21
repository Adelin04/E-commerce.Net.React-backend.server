namespace Ecommerce.API.Models;

public class Product
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string PicturePath { get; set; }
    public long Stock { get; set; }
    public string Category { get; set; }
    public Currency Currency { get; set; } = Currency.EURO;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime updatedAt { get; set; } = DateTime.UtcNow;
}