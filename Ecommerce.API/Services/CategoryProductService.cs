﻿using Ecommerce.API.Contracts;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;
using Ecommerce.API.Repositories;

namespace Ecommerce.API.Services;

public class CategoryProductService
{
    private readonly ICategoryProduct _categoryProductRepository;
    
    public CategoryProductService(ICategoryProduct categoryProductRepository)
    {
        this._categoryProductRepository = categoryProductRepository;
    }

    public async Task<CategoryProduct> AddNewCategoryProduct_ServiceAsync(
        CategoryProductDataRegister categoryProductDataRegister)
    {
        CategoryProduct newCategoryProduct = null;

        if (categoryProductDataRegister is null)
            return null;
        
        newCategoryProduct.Name = categoryProductDataRegister.Name;
        var newCategoryProductCreated = 
            this._categoryProductRepository.AddNewCategoryProductAsync(newCategoryProduct);
        
        return newCategoryProduct;
    }
}