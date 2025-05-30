using MessageBroker.AuthService.Abstractions;
using MessageBroker.AuthService.JwtInfrastructure;

namespace MessageBroker.AuthService.DataAccess.Services;

public class AuthService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly JwtProvider  _jwtProvider;

    public AuthService(
        IUsersRepository usersRepository,
        IPasswordHasher passwordHasher,
        JwtProvider jwtProvider)
    {
        _usersRepository = usersRepository;
        _passwordHasher = passwordHasher;
        _jwtProvider = jwtProvider;
    }
    
    
}