using Ecommerce.API.Contracts;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;

namespace Ecommerce.API.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        this._userRepository = userRepository;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await this._userRepository.GetAllUsersAsync();
    }

    public Task<User> GetUserById(long id)
    {
        return this._userRepository.GetUserByIdAsync(id);
    }

    public async Task<User> UpdateUserById(long id, UserDataUpdate userDataUpdate)
    {
        return await this._userRepository.UpdateUserByIdAsync(id, userDataUpdate);
    }

    public async Task<User> DeleteUserById(long id)
    {
        return await this._userRepository.DeleteUserByIdAsync(id);
    }
}