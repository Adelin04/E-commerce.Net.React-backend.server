using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerce.API.Models;

public class Role
{
    [Key] public long Id { get; set; }
    [Column(name: "Name")] public string Name { get; set; } = string.Empty;
    [Column("RoleUser")] public virtual ICollection<UserRole> UserRoles { get; set; }
}