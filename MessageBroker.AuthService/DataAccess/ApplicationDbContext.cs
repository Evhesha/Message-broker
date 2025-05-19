using MessageBroker.AuthService.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessageBroker.AuthService.DataAccess;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserEntity?> Users { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }
}