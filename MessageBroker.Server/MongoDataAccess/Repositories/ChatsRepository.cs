namespace MessageBroker.Server.MongoDataAccess;

public class ChatsRepository
{
    private readonly MongoDbContext _context;

    public ChatsRepository(MongoDbContext context)
    {
        _context = context;
    }
    
    
}