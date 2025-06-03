using MessageBroker.AuthService.Abstractions;
using MessageBroker.AuthService.Contracts;
using MessageBroker.AuthService.DTOs;
using MessageBroker.AuthService.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MessageBroker.AuthService.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserDto?>> Register([FromBody] RegisterContract regContract)
    {
        var user = new UserEntity
        {
            Id = Guid.NewGuid(),
            Name = regContract.Name,
            Email = regContract.Email,
            PasswordHash = regContract.Password
        };
        
        await _authService.Register(user.Name, user.Email, user.PasswordHash);
        return Ok(new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email
        });
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login([FromBody] LoginContract loginContract)
    {
        try
        {
            var token = await _authService.Login(loginContract.Email, loginContract.Password);
            return Ok(token);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(ex.Message);   
        }
    }
}