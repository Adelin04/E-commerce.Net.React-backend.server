using Ecommerce.API.Services;
using Ecommerce.API.Contracts;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers;

[ApiController]
[Route("api/[controller]/v1")]
public class AuthController : ControllerBase
{
    private readonly AuthService _authService;
    private readonly ILogger<AuthController> Logger;

    public AuthController(AuthService authService, ILogger<AuthController> logger)
    {
        this._authService = authService;
        this.Logger = logger;
    }

    [HttpPost("create/newUser")]
    public async Task<ActionResult> CreateNewUser([FromBody] UserDataRegister userDataRegister)
    {
        try
        {
            var userCreated = await this._authService.Register(userDataRegister);

            if (userCreated is null)
                return Ok(new { Success = true, UserCreated = userCreated });
            return BadRequest(new { Success = false, Message = "Users already exist!" });
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error -> " + exception.Message);
            this.Logger.LogInformation("Error -> " + exception.Message);
            return BadRequest(new { Error = exception.Message });
        }
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login(UserDataLogin userDataLogin)
    {
        try
        {
            var userLogged = this._authService.Login(userDataLogin);

            if (userLogged is not null)
                return Ok(new { Success = true, UserLogged = userLogged });
            return BadRequest(new { Success = false, Message = "There is no account with this email address yet !" });
        }
        catch (Exception exception)
        {
            Console.WriteLine("Error -> " + exception.Message);
            this.Logger.LogInformation("Error -> " + exception.Message);
            return BadRequest(new { Error = exception.Message });
        }
    }
}