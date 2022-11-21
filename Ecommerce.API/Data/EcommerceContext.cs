using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Data;

public class EcommerceContext : DbContext
{
    protected readonly IConfiguration _configuration;

    public EcommerceContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<User>(entity => { entity.HasIndex(field => field.Email).IsUnique(); });
    }
}