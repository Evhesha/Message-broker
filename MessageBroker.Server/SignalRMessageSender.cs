using MessageBroker.Server.Hubs;
using Microsoft.AspNetCore.SignalR;

public class SignalRMessageSender : IMessageSender
{
    private readonly IHubContext<MessageHub> _hubContext;

    public SignalRMessageSender(IHubContext<MessageHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMessage(string message)
    {
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
    }
}