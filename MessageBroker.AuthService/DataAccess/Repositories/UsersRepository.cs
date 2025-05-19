using MessageBroker.AuthService.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageBroker.AuthService.DataAccess.Repositories;

public class UsersRepository
{
    ApplicationDbContext _context;
    
    public UsersRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public UserEntity? GetUser(string email)
    {
        return _context.Users.
            FirstOrDefault(u => u.Email == email);
    }
}