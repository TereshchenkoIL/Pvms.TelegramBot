namespace Pvms.TelegramBot.MessageHandler;

public interface ICommandHandlerFactory
{
    public IDictionary<string, ICommandHandler> CreateHandlers();
}