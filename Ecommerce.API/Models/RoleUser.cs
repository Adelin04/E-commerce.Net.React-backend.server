using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.API.Models;

public class RoleUser
{
    [Key] public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    // public string UserId { get; set; }
}