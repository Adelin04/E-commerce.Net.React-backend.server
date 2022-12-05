using Ecommerce.API.Contracts;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;

namespace Ecommerce.API.Services;

public class CategoryProductService
{
    private readonly ICategoryProduct _categoryProduct;
    
    public CategoryProductService(ICategoryProduct categoryProduct)
    {
        this._categoryProduct = categoryProduct;
    }

    public async Task<CategoryProduct> AddNewCategoryProduct_ServiceAsync(
        CategoryProductDataRegister categoryProductDataRegister)
    {

        return new CategoryProduct();
    }
}