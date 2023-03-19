using Pvms.DAL;
using Telegram.Bot.Types;

namespace Pvms.TelegramBot.MessageHandler;

public class StartCommandHandler : ICommandHandler
{
    public Task<string> HandleAsync(Update update)
    {
        var message = @$"Вітаю тебе в боті для абітурієнтів з інформацією про Дні відкритих дверей.

Натисни на {CommandConstants.Bachelor}, якщо тобі цікава інформація для бакалаврів, натисни на {CommandConstants.Master}, якщо тобі цікава інформація для магістрів.

Натисни {CommandConstants.Statistics} для перегляду статистики бота";
        return Task.FromResult(message);
    }
}