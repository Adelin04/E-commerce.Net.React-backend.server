using Ecommerce.API.Services;
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
        return null;
    }
}