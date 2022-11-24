using System.ComponentModel.DataAnnotations;

namespace Ecommerce.API.Models;

public class CategoryProduct
{
    [Key]
    public long Id { get; set; }
    public string Name { get; set; }
}