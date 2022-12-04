using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Models;

public class CategoryProduct
{
    public CategoryProduct()
    {
        
    }
    public long Id { get; set; }
    public string Name { get; set; }
}