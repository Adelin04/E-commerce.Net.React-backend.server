using Ecommerce.API.Models;

namespace Ecommerce.API.Interfaces;

public interface ICategoryProduct
{
    Task<CategoryProduct> AddNewCategoryProductAsync(CategoryProduct newCategoryProduct);
    Task<List<CategoryProduct>> GetAllCategoriesProductAsync();
    Task<CategoryProduct> GetCategoryProductByIdAsync();
    Task<CategoryProduct> GetCategoryProductByNameAsync();
}
