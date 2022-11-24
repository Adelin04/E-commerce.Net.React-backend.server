using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.API.Models;

public class Product
{
    [Key] public long Id { get; set; }
    [Column("Name")] public string Name { get; set; }
    [Column("Brand")] public string Brand { get; set; }
    [Column("Color")] public string Color { get; set; }
    [Column("Description")] public string Description { get; set; }
    [Column("Price")] public double Price { get; set; }
    [Column("PicturePath")] public string PicturePath { get; set; }
    [Column("Stock")] public long Stock { get; set; }
    [Column("Category")] public string Category { get; set; }
    [Column("Currency")] public Currency Currency { get; set; } = Currency.EURO;
    [Column("CreatedAt")] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    [Column("UpdateAt")] public DateTime updatedAt { get; set; } = DateTime.UtcNow;
}