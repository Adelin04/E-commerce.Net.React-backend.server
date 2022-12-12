﻿using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Data;

public class EcommerceContext : DbContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Role { get; set; }
    public virtual DbSet<UserRole> UserRoles { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<Size> Sizes { get; set; }
    public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }


    public EcommerceContext(DbContextOptions options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(user => user.Id);
        modelBuilder.Entity<Product>().HasKey(product => product.Id);
        modelBuilder.Entity<CategoryProduct>().HasKey(categoryProduct => categoryProduct.Id);
        modelBuilder.Entity<Size>().HasKey(size => size.Id);
        modelBuilder.Entity<Role>().HasKey(role => role.Id);
        modelBuilder.Entity<UserRole>().HasKey(userRole =>
            new
            {
                userRole.UserId,
                userRole.RoleId,
            });

        // Relationships table User,Role,UserRole
        modelBuilder.Entity<UserRole>()
            .HasOne<User>(userRole => userRole.User)
            .WithMany(user => user.Roles)
            .HasForeignKey(userRole => userRole.UserId);

        modelBuilder.Entity<UserRole>()
            .HasOne<Role>(sc => sc.Role)
            .WithMany(s => s.UserRoles)
            .HasForeignKey(sc => sc.RoleId);


        modelBuilder.Entity<Product>(entity =>
        {
            //Relationships table Product,CategoryProduct
            entity
                .HasOne<CategoryProduct>(product => product.CategoryProduct);

            //Relationships table Product,Size
            entity.HasMany(product => product.Sizes);
        });
    }
}