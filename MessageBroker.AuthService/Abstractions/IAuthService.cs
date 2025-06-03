using MessageBroker.AuthService.DTOs;
using MessageBroker.AuthService.Entities;

namespace MessageBroker.AuthService.Abstractions;

public interface IAuthService
{
    Task<UserDto?> Register(string name, string email, string password);
    Task<string> Login(string email, string password);
}