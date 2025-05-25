using MessageBroker.AuthService.Entities;

namespace MessageBroker.AuthService.Abstractions;

public interface IUsersService
{
    Task<List<UserEntity>> GetUsers();
    Task<UserEntity?> GetUserByEmail(string email);
    Task<UserEntity?> CreateUser(UserEntity user);
    Task<Guid?> UpdateUser(Guid id, string name);
    Task<bool> DeleteUser(Guid id);
}