using MessageBroker.AuthService.Abstractions;
using MessageBroker.AuthService.DTOs;
using MessageBroker.AuthService.Entities;
using MessageBroker.AuthService.JwtInfrastructure;

namespace MessageBroker.AuthService.DataAccess.Services;

public class AuthService : IAuthService
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

    public async Task<UserDto?> Rigister(UserEntity user)
    {
        var hashedPassword = _passwordHasher.Generate(user.PasswordHash);

        var userEntity = new UserEntity
        {
            Id = Guid.NewGuid(),
            Name = user.Name,
            Email = user.Email,
            PasswordHash = hashedPassword,
        };
        
        await _usersRepository.CreateUser(userEntity);

        return new UserDto
        {
            Id = userEntity.Id,
            Name = userEntity.Name,
            Email = userEntity.Email
        };
    }

    public async Task<string> Login(string email, string password)
    {
        var userEntity = await _usersRepository.GetUserByEmail(email);
        
        if (userEntity == null || !_passwordHasher.Verify(password, userEntity.PasswordHash))
            throw new UnauthorizedAccessException("Authorization failed");
        
        return _jwtProvider.GenerateToken(userEntity);
    }
}