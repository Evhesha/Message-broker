public interface IMessageSender
{
    Task SendMessage(string message, string chatId);
}