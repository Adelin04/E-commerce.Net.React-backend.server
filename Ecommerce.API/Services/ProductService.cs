﻿using Ecommerce.API.Contracts;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;

namespace Ecommerce.API.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        this._productRepository = _productRepository;
    }

    public async Task<Product> CreateNewProduct(ProductDataRegister productDataRegister)
    {
        Product newProduct = null;

        if (productDataRegister is not null)
        {
            newProduct = new Product();
            newProduct.Name = productDataRegister.Name;
            newProduct.Brand = productDataRegister.Brand;
            newProduct.Category = productDataRegister.Category;
            newProduct.Color = productDataRegister.Color;
            newProduct.Description = productDataRegister.Description;
            newProduct.Price = productDataRegister.Price;
            newProduct.Stock = productDataRegister.Stock;
            newProduct.PicturePath = productDataRegister.PicturePath;
        }

        var newProductCreated = await this._productRepository.CreateNewProductAsync(newProduct);

        return newProduct;
    }

    public async Task<Product> GetProductById(long id)
    {
        var productById = await this._productRepository.GetProductByIdAsync(id);

        if (productById is not null)
            return productById;
        return null;
    }

    public async Task<List<Product>> GetAllProducts()
    {
        var listAllProducts = await this._productRepository.GetAllProductsAsync();

        if (listAllProducts is not null)
            return listAllProducts;
        return null;
    }

    public async Task<Product> UpdateProductById(long id, ProductDataUpdate productDataUpdate)
    {
        return await this._productRepository.UpdateProductByIdAsync(id, productDataUpdate);
    }

    public async Task<Product> DeleteProductById(long id)
    {
        var removedProduct = await this._productRepository.DeleteProductByIdAsync(id);

        if (removedProduct is not null)
            return removedProduct;
        return null;
    }
}