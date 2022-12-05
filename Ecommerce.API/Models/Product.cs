using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.API.Models;

public class Product
{
    public Product()
    {
        Currency = new Currency().EURO.ToString();
        CreatedAt = new DateTime().Date;
        UpdatedAt = new DateTime().Date;
    }

    public long Id { get; set; }
    public string Name { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string PicturePath { get; set; }
    public long Stock { get; set; }
    public string Currency { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    // public string Category { get; set; }
    public long CategoryProductId { get; set; }
    public virtual CategoryProduct CategoryProduct { get; set; }
}