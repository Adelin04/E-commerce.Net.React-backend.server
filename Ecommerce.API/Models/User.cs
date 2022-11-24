using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Models;

public class User
{
    [Key] public long Id { get; set; }
    [Column("FirstName")] public string FirstName { get; set; } = string.Empty;
    [Column("LastName")] public string LastName { get; set; } = string.Empty;
    [Column("Email")] public string Email { get; set; } = string.Empty;

    [Column("RoleUser")] public List<string> rolesUser { get; set; } = new List<string> { "ROLE_USER" };

    [Column("Password")] public string Password { get; set; } = string.Empty;
    [Column("ProfileImagePath")] public string ProfileImagePath { get; set; } = string.Empty;
    [Column("CreatedAt")] public DateTime CreatedAt { get; set; } = new DateTime().Date;
    [Column("UpdateAt")] public DateTime UpdatedAt { get; set; } = new DateTime().Date;
}