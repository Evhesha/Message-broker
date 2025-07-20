using MessageBroker.Server.Abstractions;
using MessageBroker.Server.Hubs;
using MessageBroker.Server.Models;
using Microsoft.AspNetCore.SignalR;

public class SignalRMessageSender : IMessageSender
{
    private readonly IHubContext<MessageHub> _hubContext;
    private readonly IServiceScopeFactory  _serviceScopeFactory;
    public SignalRMessageSender(
        IHubContext<MessageHub> hubContext,
        IServiceScopeFactory  serviceScopeFactory
        )
    {
        _hubContext = hubContext;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task SendMessage(string messageResponse)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var messagesService = scope.ServiceProvider.GetRequiredService<IMessagesService>();
        
        var message = new Message
        {
            Type = "chatResponse",
            Text = messageResponse,
            Date = DateTime.Now
        };
        
        //await _messagesService.AddMessageToChat(message);
        
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", messageResponse);
    }
}