namespace Ecommerce.API.Models;

public class User
{
    public long Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<RoleUser> rolesUser { get; set; }
    public string Password { get; set; } = string.Empty;
    public string ProfileImagePath { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = new DateTime().Date;
    public DateTime UpdatedAt { get; set; } = new DateTime().Date;
}