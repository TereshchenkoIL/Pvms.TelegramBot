using Telegram.Bot.Types;

namespace Pvms.TelegramBot.MessageHandler;

public interface ICommandHandler
{
    public Task<string> HandleAsync(Update update);
}