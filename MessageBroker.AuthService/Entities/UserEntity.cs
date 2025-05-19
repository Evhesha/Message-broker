namespace MessageBroker.AuthService.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string HashedPassword { get; set; }
    public string Email { get; set; }
}