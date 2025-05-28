using MessageBroker.AuthService.Abstractions;
using MessageBroker.AuthService.DTOs;
using MessageBroker.AuthService.Entities;

namespace MessageBroker.AuthService.DataAccess.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;

    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    public async Task<List<UserEntity>> GetUsers()
    {
        return await _usersRepository.GetUsers();
    }

    public async Task<UserEntity?> GetUserByEmail(string email)
    {
        return await _usersRepository.GetUserByEmail(email);
    }

    public async Task<UserDto?> CreateUser(UserEntity user)
    {
        return await _usersRepository.CreateUser(user);
    }

    public async Task<Guid?> UpdateUser(Guid id, string name)
    {
        return await _usersRepository.UpdateUser(id, name);
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        return await _usersRepository.DeleteUser(id);
    }
}