using Telegram.Bot.Types;

namespace Pvms.TelegramBot.MessageHandler;

public interface IMessageHandler
{
    public Task<string> HandleMessageAsync(Update update);
}