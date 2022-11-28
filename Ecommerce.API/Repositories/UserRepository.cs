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
        var findUserById = await this._context.Users.FirstOrDefaultAsync(user => user.Id == id);
        return findUserById;
    }

    public async Task<User> UpdateUserByIdAsync(long id, UserDataUpdate userDataUpdate)
    {
        var findUserById = await this._context.Users.FirstOrDefaultAsync(user => user.Id == id);

        findUserById.FirstName = userDataUpdate.FirstName;
        findUserById.LastName = userDataUpdate.LastName;
        findUserById.ProfileImagePath = userDataUpdate.ProfileImagePath;
        findUserById.Email = userDataUpdate.Email;

        await this._context.SaveChangesAsync();

        return findUserById;
    }

    public async Task<User> DeleteUserByIdAsync(long id)
    {
        var foundUserById = await this._context.Users.FirstOrDefaultAsync(user => user.Id == id);
        var removedUserById = this._context.Users.Remove(foundUserById);

        if (removedUserById.State == EntityState.Deleted)
            return foundUserById;
        return null;
    }
}