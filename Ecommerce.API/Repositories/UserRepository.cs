using Ecommerce.API.Contracts;
using Ecommerce.API.Data;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EcommerceContext _context;

    public UserRepository(EcommerceContext context)
    {
        this._context = context;
    }

    public async Task<User> DeleteUserByIdAsync(long id)
    {
        var findUser = await this._context.Users.FirstOrDefaultAsync(user => user.Id == id);
        await this._context.FindAsync<User>();
        return findUser;
    }

    public async Task<List<User>> GetAllUsersAsync()
    {
        var usersList = await this._context.Users.ToListAsync();
        return usersList;
    }

    public async Task<User> GetUserByEmailAsync(string email)
    {
        var foundUserByEmail = await this._context.Users.FirstOrDefaultAsync(user => user.Email == email);
        return foundUserByEmail;
    }

    public async Task<User> GetUserByIdAsync(long id)
    {
        var foundUserById = await this._context.Users.FirstOrDefaultAsync(user => user.Id == id);
        return foundUserById;
    }

    public async Task<User> UpdateUserByIdAsync(long id, UserDataUpdate userDataUpdate)
    {
        var foundUserById = await this._context.Users.FirstOrDefaultAsync(user => user.Id == id);

        foundUserById.FirstName = userDataUpdate.FirstName;
        foundUserById.LastName = userDataUpdate.LastName;
        foundUserById.ProfileImagePath = userDataUpdate.ProfileImagePath;
        foundUserById.Email = userDataUpdate.Email;

        await this._context.SaveChangesAsync();

        return foundUserById;
    }
}