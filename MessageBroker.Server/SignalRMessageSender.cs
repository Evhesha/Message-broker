using MessageBroker.Server.Abstractions;
using MessageBroker.Server.Hubs;
using MessageBroker.Server.Models;
using Microsoft.AspNetCore.SignalR;

public class SignalRMessageSender : IMessageSender
{
    private readonly IHubContext<MessageHub> _hubContext;
    //private readonly IMessagesService _messagesService;
    public SignalRMessageSender(
        IHubContext<MessageHub> hubContext
        //IMessagesService messagesService
        )
    {
        _hubContext = hubContext;
       // _messagesService = messagesService;
    }

    public async Task SendMessage(string messageResponse)
    {
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