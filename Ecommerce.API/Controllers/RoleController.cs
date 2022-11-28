using Ecommerce.API.Contracts;
using Ecommerce.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("api/[controller]/v1")]
public class RoleController : ControllerBase
{
    private readonly RoleService _roleService;
    private readonly ILogger<RoleController> Logger;

    public RoleController(RoleService roleService, ILogger<RoleController> logger)
    {
        this.Logger = logger;
        this._roleService = roleService;
    }

    [HttpPost("create/newRole/")]
    public async Task<ActionResult> CreateNewRole([FromBody] RoleDataCreateNewRole dataCreateNewRole)
    {
        try
        {
            var newRoleCreated = await this._roleService.CreateNewRoleAsync(dataCreateNewRole);

            if (newRoleCreated is not null)
            {
                this.Logger.LogInformation($"New role was created -> {dataCreateNewRole}");
                return Ok(new { Success = true, RoleCreated = dataCreateNewRole });
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error -> " + exception.Message);
            this.Logger.LogInformation(exception.Message.ToString());
        }


        this.Logger.LogInformation($"The role {dataCreateNewRole} could not be created!");
        return BadRequest(new { Success = false, Message = $"The role {dataCreateNewRole} could not be created!" });
    }

    [HttpPut("update/roleById/{id}")]
    public async Task<ActionResult> UpdateRoleById([FromRoute] long id, [FromBody] RoleDataUpdate roleDataUpdate)
    {
        try
        {
            var updatedRole = await this._roleService.UpdateRoleById(id, roleDataUpdate);

            if (updatedRole is not null)
            {
                this.Logger.LogInformation($"New role was updated -> {roleDataUpdate.name}");
                return Ok(new { Success = true, RoleUpdated = updatedRole });
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error -> " + exception.Message);
            this.Logger.LogInformation(exception.Message.ToString());
        }


        this.Logger.LogInformation($"The role {roleDataUpdate.name} could not be updated!");
        return BadRequest(new { Success = false, Message = $"The role {roleDataUpdate.name} could not be updated!" });
    }

    [HttpDelete("delete/roleById/{id}")]
    public async Task<ActionResult> DeleteRoleById([FromRoute] long id)
    {
        var deletedRole = await this._roleService.DeleteRoleById(id);
        try
        {
            if (deletedRole is not null)
            {
                this.Logger.LogInformation($"Role {deletedRole.Name} was removed from DB");
                return Ok(new { Success = true, RoleUpdated = deletedRole.Name });
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error -> " + exception.Message);
            this.Logger.LogInformation(exception.Message.ToString());
        }


        this.Logger.LogInformation($"The role {deletedRole.Name} could not be removed from DB!");
        return BadRequest(new
            { Success = false, Message = $"The role {deletedRole.Name} could not be removed from DB!" });
    }
}