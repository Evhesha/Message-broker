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

    public async Task<List<UserEntity?>> GetUsers()
    {
        return await _context.Users
            .ToListAsync();
    }

    public async Task<UserEntity?> GetUserByEmail(string email)
    {
        return await _context.Users.
            FirstOrDefaultAsync(u => u.Email == email);
    }
    
    

    public async Task<UserEntity?> DeleteUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user != null)
        {
            _context.Remove(user);
            await _context.SaveChangesAsync();
        }
        
        return user;
    }
}