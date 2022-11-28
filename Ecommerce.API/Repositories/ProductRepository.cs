﻿using Ecommerce.API.Contracts;
using Ecommerce.API.Data;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly EcommerceContext _context;

    public ProductRepository(EcommerceContext context)
    {
        this._context = context;
    }

    public async Task<Product> CreateNewProductAsync(Product newProduct)
    {
        var newProductCreated = await this._context.Products.AddAsync(newProduct);

        if (newProductCreated.State is EntityState.Added)
            return newProduct;
        return null;
    }

    public async Task<Product> GetProductByIdAsync(long id)
    {
        var foundProductById = await this._context.Products.FirstOrDefaultAsync(product => product.Id == id);

        if (foundProductById is not null)
            return foundProductById;
        return null;
    }

    public async Task<List<Product>> GetAllProductsAsync()
    {
        var listAllProducts = await this._context.Products.ToListAsync();

        if (listAllProducts is not null)
            return listAllProducts;
        return null;
    }

    public async Task<Product> DeleteProductByIdAsync(long id)
    {
        var foundProductById = await this._context.Products.FirstOrDefaultAsync(product => product.Id == id);
        var removedProductById = this._context.Products.Remove(foundProductById);

        if (removedProductById.State is EntityState.Deleted)
            return foundProductById;
        return null;
    }

    public async Task<Product> UpdateProductByIdAsync(long id, ProductDataUpdate productDataUpdate)
    {
        var foundProductById = await this._context.Products.FirstOrDefaultAsync(product => product.Id == id);

        if (foundProductById is not null)
        {
            foundProductById.Name = productDataUpdate.Name;
            foundProductById.Brand = productDataUpdate.Brand;
            foundProductById.Category = productDataUpdate.Category;
            foundProductById.Color = productDataUpdate.Color;
            foundProductById.Description = productDataUpdate.Description;
            foundProductById.Price = productDataUpdate.Price;
            foundProductById.Stock = productDataUpdate.Stock;
            foundProductById.PicturePath = productDataUpdate.PicturePath;

            this._context.SaveChangesAsync();
        }

        return foundProductById;
    }
}