using MessageBroker.AuthService.Abstractions;
using MessageBroker.AuthService.DTOs;
using MessageBroker.AuthService.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageBroker.AuthService.DataAccess.Repositories;

public class UsersRepository : IUsersRepository
{
    private readonly ApplicationDbContext _context;
    
    public UsersRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<UserEntity>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<UserEntity?> GetUserByEmail(string email)
    {
        return await _context.Users.
            FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<UserDTO?> CreateUser(UserEntity user)
    {
        if (user == null) return null;

        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
    
        return new UserDTO
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
        };
    }
    
    public async Task<Guid?> UpdateUser(Guid id, string name)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null) return null;
        
        user.Name = name;
        await _context.SaveChangesAsync();

        return id;
    }

    public async Task<bool> DeleteUser(Guid id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null) return false;
        
        _context.Remove(user);
        await _context.SaveChangesAsync();
        
        return true;
    }
}