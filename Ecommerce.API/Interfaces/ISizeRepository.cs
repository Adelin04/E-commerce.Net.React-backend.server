using Ecommerce.API.Models;

namespace Ecommerce.API.Interfaces;

public interface ISizeRepository
{
    public Task<Size> CreateNewSize();
    public Task<List<Size>> GetAllSize();
    public Task<Size> GetAllSizeById(long id);
    public Task<Size> GetAllSizeByName(string name);
}