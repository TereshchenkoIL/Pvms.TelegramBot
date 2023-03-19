using Pvms.DAL;
using Telegram.Bot.Types;

namespace Pvms.TelegramBot.MessageHandler;

public class MasterCommandHandler : ICommandHandler
{
    public Task<string> HandleAsync(Update update)
    {
        var message = $@"Введіть спеціальність, яка вас цікавить:
{CommandConstants.M121} - для 121 спеціальності
{CommandConstants.M122} - для 122 спеціальності
{CommandConstants.M123} - для 123 спеціальності";
        return Task.FromResult(message);
    }
}