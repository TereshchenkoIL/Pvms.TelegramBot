using Pvms.DAL;
using Telegram.Bot.Types;

namespace Pvms.TelegramBot.MessageHandler;

public class BachelorCommandHandler : ICommandHandler
{
    public Task<string> HandleAsync(Update update)
    {
        var message = $@"Введіть спеціальність, яка вас цікавить:
{CommandConstants.B121} - для 121 спеціальності
{CommandConstants.B122} - для 122 спеціальності
{CommandConstants.B123} - для 123 спеціальності";
       return Task.FromResult(message);
    }
}