using MessageBroker.AuthService.Abstractions;
using MessageBroker.AuthService.DTOs;
using MessageBroker.AuthService.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MessageBroker.AuthService.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUsersRepository _usersRepository;

    public UsersController(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    // public async ActionResult<List<UserEntity>> GetUsers()
    // {
    //     return null;
    // }

    [HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUser(UserEntity user)
    {
        var userEnity = new UserEntity
        {
            Id = Guid.NewGuid(),
            Name = user.Name,
            PasswordHash = user.PasswordHash,
            Email = user.Email
        };
        
        if (string.IsNullOrWhiteSpace(user.Name) 
            || string.IsNullOrWhiteSpace(user.Email) 
            || string.IsNullOrWhiteSpace(user.PasswordHash))
            return BadRequest("Invalid users data.");

        await _usersRepository.CreateUser(userEnity);
        
        return new UserDTO
        {
            Id = userEnity.Id,
            Name = userEnity.Name,
            Email = userEnity.Email
        };
    }
}