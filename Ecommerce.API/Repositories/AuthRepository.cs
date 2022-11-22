using Ecommerce.API.Contracts;
using Ecommerce.API.Data;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;

namespace Ecommerce.API.Repositories;

public class AuthRepository : IAuthRepository
{
    private readonly EcommerceContext _context;

    public AuthRepository(EcommerceContext context)
    {
        this._context = context;
    }

    public async Task<User> CreateUserAsync(User newUser)
    {
        await this._context.Users.AddAsync(newUser);
        return newUser;
    }
}