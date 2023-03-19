using Autofac;
using Telegram.Bot.Types;

namespace Pvms.TelegramBot.MessageHandler;

public class BotMessageHandler : IMessageHandler
{
    private readonly ILifetimeScope _scope;

    public BotMessageHandler(ILifetimeScope scope)
    {
        _scope = scope;
    }
    
    public async Task<string> HandleMessageAsync(Update update)
    {
        if (update.Type != Telegram.Bot.Types.Enums.UpdateType.Message 
            || string.IsNullOrWhiteSpace(update.Message?.Text))
        {
            return String.Empty;
        }

        var command = update.Message.Text;
        // Отримання ICommandHandlerFactory з контейнеру інверсії управління
        var handlersFactory = _scope.Resolve<ICommandHandlerFactory>();
        // Створення оброблювачів
        var handlers = handlersFactory.CreateHandlers();

        if (!handlers.ContainsKey(command))
        {
            throw new ArgumentOutOfRangeException();
        }

        // Виклик відповідного оброблювача
        return await handlers[command].HandleAsync(update);
    }
}