using Ecommerce.API.Contracts;
using Ecommerce.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("api/[controller]/v1")]
public class ProductController : ControllerBase
{
    private readonly ProductService _productService;
    private readonly ILogger<ProductController> Logger;

    public ProductController(ProductService productService, ILogger<ProductController> logger)
    {
        this._productService = productService;
        this.Logger = logger;
    }

    [HttpPost("register/newProduct")]
    public async Task<ActionResult> CreateNewProduct([FromBody] ProductDataRegister productDataRegister)
    {
        try
        {
            var newProductCreated = await this._productService.CreateNewProduct(productDataRegister);

            if (newProductCreated is not null)
                return Ok(new { Success = true, ProductCreated = newProductCreated });
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error -> " + exception.Message);
            this.Logger.LogInformation("Error -> " + exception.Message);
            return BadRequest(new { Error = exception.Message });
        }

        return BadRequest(new { Success = false, Message = "The product could not be created!" });
    }
    
    [HttpGet("get/productById/{id}")]
    public async Task<ActionResult> GetProductById([FromRoute] long id)
    {
        try
        {
            var productById = await this._productService.GetProductById(id);

            if (productById is not null)
                return Ok(new { Success = true, ProductById = productById });
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error -> " + exception.Message);
            this.Logger.LogInformation("Error -> " + exception.Message);
        }

        return BadRequest(new { Success = false, Message = "No product found!" });
    }


    [HttpPut("update/productById/{id}")]
    public async Task<ActionResult> UpdateProductById([FromRoute] long id, [FromBody] ProductDataUpdate productDataUpdate)
    {
        var updatedProduct = await this._productService.UpdateProductById(id, productDataUpdate);
        try
        {
            if (productDataUpdate is not null)
            {
                this.Logger.LogInformation($"New product was updated -> {productDataUpdate.Name}");
                return Ok(new { Success = true, ProductUpdated = productDataUpdate });
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error -> " + exception.Message);
            this.Logger.LogInformation(exception.Message.ToString());
        }


        this.Logger.LogInformation($"The product {productDataUpdate.Name} could not be updated!");
        return BadRequest(new
            { Success = false, Message = $"The product {productDataUpdate.Name} could not be updated!" });
    }

    [HttpDelete("delete/productById/{id}")]
    public async Task<ActionResult> DeleteProductById([FromRoute] long id)
    {
        var removedProduct = await this._productService.DeleteProductById(id);
        try
        {
            if (removedProduct is not null)
            {
                this.Logger.LogInformation($"Product {removedProduct.Name} was removed from DB");
                return Ok(new { Success = true, RoleUpdated = removedProduct.Name });
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error -> " + exception.Message);
            this.Logger.LogInformation(exception.Message.ToString());
        }


        this.Logger.LogInformation($"The product {removedProduct.Name} could not be removed from DB!");
        return BadRequest(new
            { Success = false, Message = $"The product {removedProduct.Name} could not be removed from DB!" });
    }
}