using MessageBroker.AuthService.Abstractions;

namespace MessageBroker.AuthService.DataAccess.Services;

public class AuthService
{
    private readonly IUsersRepository _usersRepository;

    public AuthService(
        IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }
}