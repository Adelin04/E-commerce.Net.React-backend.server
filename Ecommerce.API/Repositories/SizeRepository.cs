using Ecommerce.API.Data;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repositories;

public class SizeRepository : ISizeRepository
{
    private readonly EcommerceContext _context;

    public SizeRepository(EcommerceContext context)
    {
        this._context = context;
    }

    public Task<Size> CreateNewSize()
    {
        throw new NotImplementedException();
    }

    public async Task<List<Size>> GetAllSize()
    {
        var allSizes = await this._context.Sizes.ToListAsync();

        return allSizes;
    }

    public Task<Size> GetAllSizeById(long id)
    {
        throw new NotImplementedException();
    }

    public Task<Size> GetAllSizeByName(string name)
    {
        throw new NotImplementedException();
    }
}