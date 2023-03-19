using Autofac;
using Microsoft.EntityFrameworkCore;
using Pvms.DAL;
using Telegram.Bot.Types;

namespace Pvms.TelegramBot.MessageHandler;

public class StatisticsCommandHandler : ICommandHandler
{
    private readonly ILifetimeScope _scope;

    public StatisticsCommandHandler(ILifetimeScope scope)
    {
        _scope = scope;
    }

    public async Task<string> HandleAsync(Update update)
    {
        var dataContext = _scope.Resolve<DataContext>();

        // Отримання статистики по всім користувачам з бази даних
        var userStatistics = await dataContext.UserStatistics.ToListAsync();

        var response =
            $@"Всього ботом скористалися {userStatistics.Count} особи/особа.

Статистика по запитам:
{CommandConstants.Start} - {userStatistics.Sum(x => x.StartCount)}
{CommandConstants.Bachelor} - {userStatistics.Sum(x => x.BachelorCount)}
{CommandConstants.Master} - {userStatistics.Sum(x => x.MasterCount)}
{CommandConstants.B121} - {userStatistics.Sum(x => x.B121Count)}
{CommandConstants.B122} - {userStatistics.Sum(x => x.B122Count)}
{CommandConstants.B123} - {userStatistics.Sum(x => x.B123Count)}
{CommandConstants.M121} - {userStatistics.Sum(x => x.M121Count)}
{CommandConstants.M122} - {userStatistics.Sum(x => x.M122Count)}
{CommandConstants.M123} - {userStatistics.Sum(x => x.M123Count)}
";
        return response;
    }
}