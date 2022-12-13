using Ecommerce.API.Contracts;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;

namespace Ecommerce.API.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryProductRepository _categoryProductRepository;

    public ProductService(IProductRepository productRepository, ICategoryProductRepository categoryProductRepository)
    {
        this._productRepository = productRepository;
        this._categoryProductRepository = categoryProductRepository;
    }

    public async Task<Product> CreateNewProduct_ServiceAsync(ProductDataRegister productDataRegister)
    {
        
        foreach (var VARIABLE in productDataRegister.Sizes)
        {
            Console.WriteLine(VARIABLE);
        }
        Product newProduct = null;


        var findCategoryProduct =
            await this._categoryProductRepository.GetCategoryProductByNameAsync(productDataRegister.CategoryName);

        if (findCategoryProduct is null)
            return null;

        if (productDataRegister is not null)
        {
            newProduct = new Product();
            newProduct.Name = productDataRegister.Name;
            newProduct.Brand = productDataRegister.Brand;
            newProduct.Color = productDataRegister.Color;
            newProduct.Description = productDataRegister.Description;
            newProduct.Price = productDataRegister.Price;
            // newProduct.Stock = productDataRegister.Stock;
            // newProduct.Sizes = new List<Size>{};
            newProduct.PicturePath = productDataRegister.PicturePath;

            //FOREIGNKEY
            newProduct.CategoryProductId = findCategoryProduct.Id;
        }

        var newProductCreated = await this._productRepository.CreateNewProductAsync(newProduct);

        return newProduct;
    }

    public async Task<Product> GetProductById_ServiceAsync(long id)
    {
        var productById = await this._productRepository.GetProductByIdAsync(id);

        if (productById is not null)
            return productById;
        return null;
    }

    public async Task<List<Product>> GetAllProducts_ServiceAsync()
    {
        var listAllProducts = await this._productRepository.GetAllProductsAsync();

        if (listAllProducts is not null)
            return listAllProducts;
        return null;
    }

    public async Task<Product> UpdateProductById_ServiceAsync(long id, ProductDataUpdate productDataUpdate)
    {
        return await this._productRepository.UpdateProductByIdAsync(id, productDataUpdate);
    }

    public async Task<Product> DeleteProductById_ServiceAsync(long id)
    {
        var removedProduct = await this._productRepository.DeleteProductByIdAsync(id);

        if (removedProduct is not null)
            return removedProduct;
        return null;
    }
}