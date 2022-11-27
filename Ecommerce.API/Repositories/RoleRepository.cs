﻿using Ecommerce.API.Contracts;
using Ecommerce.API.Data;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.API.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly EcommerceContext _Context;

    public RoleRepository(EcommerceContext context)
    {
        this._Context = context;
    }


    public async Task<Role> CreateNewRoleAsync(Role newRole)
    {
        var newRoleCreated = await this._Context.Role.AddAsync(newRole);

        if (newRoleCreated.State == EntityState.Added)
        {
            var roleCreated = await this._Context.SaveChangesAsync(true);

            return newRole;
        }

        return null;
    }

    public async Task<List<Role>> GetAllRolesAsync()
    {
        var allRoles = await this._Context.Role.ToListAsync();

        return allRoles;
    }

    public async Task<Role> GetRoleByIdAsync(long id)
    {
        var foundRoleById = await this._Context.Role.FirstOrDefaultAsync(role => role.Id == id);

        return foundRoleById;
    }

    public async Task<Role> GetRoleByNameAsync(string name)
    {
        var foundRoleByName = await this._Context.Role.FirstOrDefaultAsync(role => role.Name == name);

        return foundRoleByName;
    }

    public Task<Role> UpdateRoleByIdAsync(long id, RoleDataUpdate roleDataUpdate)
    {
        throw new NotImplementedException();
    }
}