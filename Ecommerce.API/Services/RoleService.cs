using Ecommerce.API.Contracts;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;

namespace Ecommerce.API.Services;

public class RoleService
{
    private readonly IRoleRepository _roleRepository;

    public RoleService(IRoleRepository roleRepository)
    {
        this._roleRepository = roleRepository;
    }

    public async Task<Role> CreateNewRoleAsync(RoleDataCreateNewRole dataCreateNewRole)
    {
        Role newRole = null;
        var existingRole = await this._roleRepository.GetRoleByNameAsync(dataCreateNewRole.nameRole);

        if (existingRole is null)
        {
            newRole = new Role();
            newRole.Name = dataCreateNewRole.nameRole;
            await this._roleRepository.CreateNewRoleAsync(newRole);
            return newRole;
        }

        return newRole;
    }
}