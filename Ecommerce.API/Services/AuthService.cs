using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Ecommerce.API.Contracts;
using Ecommerce.API.Interfaces;
using Ecommerce.API.Models;
using Microsoft.IdentityModel.Tokens;

namespace Ecommerce.API.Services;

public class AuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IAuthRepository _authRepository;
    private readonly IConfiguration _configuration;

    public AuthService(IUserRepository userRepository, IAuthRepository authRepository, IConfiguration configuration)
    {
        this._userRepository = userRepository;
        this._authRepository = authRepository;
        this._configuration = configuration;
    }


    public async Task<User> Register(UserDataRegister candidateUser)
    {
        User newUser = null;
        string DEFAULT_ROLE_USER = "ROLE_USER";
        var existingUser = await this._userRepository.GetUserByEmailAsync((candidateUser.Email));

        if (existingUser is null)
        {
            newUser = new User();
            newUser.FirstName = candidateUser.Firstname;
            newUser.LastName = candidateUser.Lastname;
            newUser.Email = candidateUser.Email;
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(candidateUser.Password);
            newUser.ProfileImagePath = candidateUser.ProfileImagePath;
            newUser.rolesUser = new List<string> { DEFAULT_ROLE_USER };

            await this._authRepository.CreateUserAsync((newUser));
        }

        return newUser;
    }
    

    public async Task<string> Login(UserDataLogin userDataLogin)
    {
        string token = null;
        var existingUser = await this._userRepository.GetUserByEmailAsync((userDataLogin.Email));

        if (existingUser is not null)
        {
            var matchPassword = BCrypt.Net.BCrypt.Verify(userDataLogin.Password, existingUser.Password);

            if (matchPassword)
                token = GenerateToken(existingUser);
        }

        return token;
    }

    private string GenerateToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this._configuration["JwtConfig:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = GetUserClaims(user);

        var token = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddDays(30),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private List<Claim> GetUserClaims(User user)
    {
        List<Claim> claimsList = new List<Claim>();

        claimsList.Add((new Claim(ClaimTypes.GivenName, user.FirstName)));
        claimsList.Add(new Claim(ClaimTypes.Surname, user.LastName));
        claimsList.Add(new Claim(ClaimTypes.Email, user.Email));

        foreach (var role in user.rolesUser)
        {
            claimsList.Add((new Claim(ClaimTypes.Role, role)));
        }

        return claimsList;
    }
}