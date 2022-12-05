using Ecommerce.API.Contracts;
using Ecommerce.API.Data;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repositories;

public class CategoryProductRepository : ICategoryProduct
{
    private readonly EcommerceContext _context;
    
    public CategoryProductRepository(EcommerceContext context)
    {
        this._context = context;
    }
    


    public async Task<CategoryProduct> AddNewCategoryProductAsync(CategoryProduct newCategoryProduct)
    {

            var newCategoryProductCreated = await this._context.CategoryProducts.AddAsync(newCategoryProduct);
        
            if(newCategoryProductCreated.State == EntityState.Added)
            {
                await this._context.SaveChangesAsync();
                return newCategoryProduct;
            }    
        return null;
    }

    public Task<List<CategoryProduct>> GetAllCategoriesProductAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryProduct> GetCategoryProductByIdAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CategoryProduct> GetCategoryProductByNameAsync()
    {
        throw new NotImplementedException();
    }
}