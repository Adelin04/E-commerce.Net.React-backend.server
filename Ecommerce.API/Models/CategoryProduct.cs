using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Models;

public class CategoryProduct
{
    public CategoryProduct()
    {
        // this.Products = new List<Product>();
    }

    public long Id { get; set; }
    public string Name { get; set; }

    // public virtual ICollection<Product> Products { get; set; }
}