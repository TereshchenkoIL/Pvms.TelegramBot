using Autofac;
using Microsoft.EntityFrameworkCore;
using Pvms.DAL;
using Telegram.Bot.Types;

namespace Pvms.TelegramBot.MessageHandler;

public class SpecialisationInfoCommandHandler : ICommandHandler
{
    private readonly ILifetimeScope _scope;

    public SpecialisationInfoCommandHandler(ILifetimeScope scope)
    {
        _scope = scope;
    }

    public async Task<string> HandleAsync(Update update)
    {
        var dataContext = _scope.Resolve<DataContext>();

        var code = update.Message!.Text.Replace("/", "");

        // Отримання інформації з бази даних
        var info = await dataContext.SpecializationInfos.FirstOrDefaultAsync(x => x.Code == code);

        return info?.Info;
    }
}