using Ecommerce.API.Models;
using Ecommerce.API.Repositories;

namespace Ecommerce.API.Services;

public class UserRoleService
{
    private readonly UserRoleRepository _userRoleRepository;

    public UserRoleService(UserRoleRepository userRoleRepository)
    {
        this._userRoleRepository = userRoleRepository;
    }

    public async Task<UserRole> AddNewUserRole(long idUser, long idRole)
    {
        var newUserRoleCreated = await this._userRoleRepository.AddNewUserRole(idUser, idRole);
        return newUserRoleCreated;
    }
}