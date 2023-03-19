using Autofac;
using Microsoft.EntityFrameworkCore;
using Pvms.DAL;
using Pvms.DAL.Entities;
using Pvms.TelegramBot.MessageHandler;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace Pvms.TelegramBot;
using Telegram.Bot;

public static class BotWrapper
{
    public static ITelegramBotClient BotClient = new TelegramBotClient("6012853614:AAHt0TOdZ_0OU8XRhuryVNafYK79u2uQn7g");
    private static IContainer _container;
    
    static BotWrapper()
    {
        // Реєстрація залежностей в контейнер інверсії управління
        var builder = new ContainerBuilder();
        builder.RegisterType<BotMessageHandler>().As<IMessageHandler>().InstancePerLifetimeScope();
        builder.RegisterType<CommandHandlerFactory>().As<ICommandHandlerFactory>().InstancePerLifetimeScope();

        builder.Register(componentContext =>
            {
                string connectionString = DalConstants.ConnectionString;
                DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>()
                    .UseSqlServer(connectionString);
                return optionsBuilder.Options;
            }).As<DbContextOptions<DataContext>>()
            .InstancePerLifetimeScope();

        builder.Register(context => context.Resolve<DbContextOptions<DataContext>>())
            .As<DbContextOptions>()
            .InstancePerLifetimeScope();

        builder.RegisterType<DataContext>()
            .AsSelf()
            .InstancePerLifetimeScope();
        
        _container = builder.Build();
    }
    
    // Початок отримання запитів
    public static void StartReceiving(ReceiverOptions receiverOptions, CancellationToken cancellationToken)
    {
        BotClient.StartReceiving( 
            HandleUpdateAsync,
            HandleErrorAsync,
            receiverOptions,
            cancellationToken);
    }

    // Глобальний оброблювач запитів
    private static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        if (update.Type != Telegram.Bot.Types.Enums.UpdateType.Message)
        {
            return;
        }
        
        using (var scope = _container.BeginLifetimeScope())
        {
            var handler = scope.Resolve<IMessageHandler>();

            var response = await handler.HandleMessageAsync(update);

            await SaveUserStatisticsAsync(update, scope);
            
            await SendResponseAsync(botClient, update, response);
        }
    }

    private static Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        return Task.CompletedTask;
    }

    // Відправка результату
    private static Task SendResponseAsync(ITelegramBotClient botClient, Update update, string response)
    {
        if (string.IsNullOrWhiteSpace(response))
        {
            return Task.CompletedTask;
        }

        return botClient.SendTextMessageAsync(update.Message!.Chat, response);
    }

    // Збереження статистики
    private async static Task SaveUserStatisticsAsync(Update update, ILifetimeScope scope)
    {
        var dataContext = scope.Resolve<DataContext>();
        var userId = update.Message.Chat.Id;
        var command = update.Message.Text ?? string.Empty;

        var userStatistics = await dataContext.UserStatistics.FirstOrDefaultAsync(x => x.Id == userId);

        if (userStatistics == null)
        {
            userStatistics = new UserStatistics
            {
                Id = userId,
                StartDate = DateTime.UtcNow
            };
            
            userStatistics.IncrementStatistic(command);
            dataContext.UserStatistics.Add(userStatistics);
            await dataContext.SaveChangesAsync();
            return;
        }
        
        userStatistics.IncrementStatistic(command);
        await dataContext.SaveChangesAsync();
    }
}