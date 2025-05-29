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

    [HttpGet]
    public async Task<ActionResult<List<UserEntity>>> GetUsers()
    {   
        return await _usersRepository.GetUsers();
    }

    [HttpGet("{email}")]
    public async Task<ActionResult<UserDto>> GetUserByEmail(string email)
    {
        var user =  await _usersRepository.GetUserByEmail(email);

        if (user == null) return NotFound();
        
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
        };
    }
    
    [HttpPost]
    public async Task<ActionResult<UserDto>> CreateUser(UserEntity user)
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
        
        return new UserDto
        {
            Id = userEnity.Id,
            Name = userEnity.Name,
            Email = userEnity.Email
        };
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(Guid id, [FromBody] UserDto user)
    {
        if (string.IsNullOrWhiteSpace(user.Name)) 
            return BadRequest("Name can't be empty");
        
        var resutl =  await _usersRepository.UpdateUser(id, user.Name);
        
        if (resutl == null) return NotFound();
        
        return new OkResult();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteUser(Guid id)
    {
        return await _usersRepository.DeleteUser(id);
    }
}