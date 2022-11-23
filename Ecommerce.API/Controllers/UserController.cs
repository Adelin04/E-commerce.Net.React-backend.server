using Ecommerce.API.Contracts;
using Ecommerce.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("api/[controller]/v1")]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    private readonly ILogger<UserController> Logger;

    public UserController(UserService userService, ILogger<UserController> logger)
    {
        this._userService = userService;
        this.Logger = logger;
    }

    [HttpGet("getAllUsers")]
    public async Task<ActionResult> GetAllUsers()
    {
        try
        {
            var listAllUsers = await this._userService.GetAllUsers();

            if (listAllUsers is not null)
                return Ok(new { Success = true, CounterUser = listAllUsers.Count });
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error -> " + exception.Message);
            this.Logger.LogInformation("Error -> " + exception.Message);
            return BadRequest(new { Error = exception.Message });
        }

        return BadRequest(new { Success = false, Message = "No users!" });
    }

    [HttpGet("get/userById/{id}")]
    public async Task<ActionResult> GetUserById([FromHeader] long id)
    {
        try
        {
            var userById = await this._userService.GetUserById(id);

            if (userById is not null)
                return Ok(new { Success = true, userById = userById });
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error -> " + exception.Message);
            this.Logger.LogInformation("Error -> " + exception.Message);
        }

        return BadRequest(new { Success = false, Message = "No user!" });
    }

    [HttpGet("update/userById/{id}")]
    public async Task<ActionResult> UpdateUserById([FromHeader] long id, [FromBody] UserDataUpdate userDataUpdate)
    {
        try
        {
            var userById = await this._userService.GetUserById(id);

            if (userById is not null)
            {
                var userUppdated = await this._userService.UpdateUserById(id, userDataUpdate);
                return Ok(new { Success = true, UserUpdated = userUppdated });
            }
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error -> " + exception.Message);
            this.Logger.LogInformation("Error -> " + exception.Message);
            return BadRequest(new { Error = exception.Message });
        }

        return BadRequest(new { Success = false, Message = "No user!" });
    }

    [HttpDelete("delete/userById/{id}")]
    public async Task<ActionResult> DeleteUserById([FromHeader] long id)
    {
        try
        {
            var userById = await this._userService.GetUserById(id);

            // if(userById is not null)
            //     await  this._userService.
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error -> " + exception.Message);
            this.Logger.LogInformation("Error -> " + exception.Message);
            return BadRequest(new { Error = exception.Message });
        }

        return BadRequest(new { Success = false, Message = "No user!" });
    }
}