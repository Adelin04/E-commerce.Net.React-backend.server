using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;

namespace Ecommerce.API.Services;

public class SizeService
{
    private readonly ISizeRepository _sizeRepository;

    public SizeService(ISizeRepository sizeRepository)
    {
        this._sizeRepository = sizeRepository;
    }

    public async Task<List<Size>> GetAllSize_ServiceAsync()
    {
        var allSizes = await this._sizeRepository.GetAllSizeAsync();
        return allSizes;
    }
}