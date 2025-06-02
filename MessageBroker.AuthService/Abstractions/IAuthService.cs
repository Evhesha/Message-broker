using MessageBroker.AuthService.DTOs;
using MessageBroker.AuthService.Entities;

namespace MessageBroker.AuthService.Abstractions;

public interface IAuthService
{
    Task<UserDto?> Rigister(UserEntity user);
    Task<string> Login(string email, string password);
}