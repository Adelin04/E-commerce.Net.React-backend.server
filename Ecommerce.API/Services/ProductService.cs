using Ecommerce.API.Contracts;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;

namespace Ecommerce.API.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;
    private readonly ICategoryProductRepository _categoryProductRepository;
    private readonly ISizeStockRepository _sizeStockRepository;
    private readonly ISizeRepository _sizeRepository;


    public ProductService(IProductRepository productRepository, ICategoryProductRepository categoryProductRepository, ISizeStockRepository sizeStockRepository, ISizeRepository sizeRepository)
    {
        this._productRepository = productRepository;
        this._categoryProductRepository = categoryProductRepository;
        this._sizeStockRepository = sizeStockRepository;
        this._sizeRepository = sizeRepository;
    }

    public async Task<Product> CreateNewProduct_ServiceAsync(ProductDataRegister productDataRegister)
    {
        List<SizeStock> listOfSize = new List<SizeStock>();
        Product newProduct = null;
        SizeStock sizeStock = null;


        var findCategoryProduct =
            await this._categoryProductRepository.GetCategoryProductByNameAsync(productDataRegister.CategoryName);

        var findSizesProduct = await this._sizeRepository.GetAllSizeAsync();

        if (findCategoryProduct is null)
            return null;

        if (productDataRegister is not null)
        {
            //register new product
            newProduct = new Product();
            newProduct.Name = productDataRegister.Name;
            newProduct.Brand = productDataRegister.Brand;
            newProduct.Color = productDataRegister.Color;
            newProduct.Description = productDataRegister.Description;
            newProduct.Price = productDataRegister.Price;
            newProduct.PicturePath = productDataRegister.PicturePath;
            newProduct.Stock = 1;

            //FOREIGNKEY
            newProduct.CategoryProductId = findCategoryProduct.Id;


        }
        var newProductCreated = await this._productRepository.CreateNewProductAsync(newProduct);
        
        
            //register new size and stock product
        if(newProductCreated is not null)
            foreach (var size in productDataRegister.Sizes)
            {
                var verifySizeExist = findSizesProduct.Find(item=>item.Name == size.Size);
                
                listOfSize.Add(new SizeStock { Stock = size.Stock, FK_ProductId = newProductCreated.Id, FK_SizeId =  verifySizeExist.Id});
            }
        var newListOfSizeStockRegistered = await this._sizeStockRepository.RegisterListOfNewSizeStockAsync(listOfSize);

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