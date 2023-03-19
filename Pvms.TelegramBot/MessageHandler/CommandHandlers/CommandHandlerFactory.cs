using Autofac;
using Pvms.DAL;

namespace Pvms.TelegramBot.MessageHandler;

public class CommandHandlerFactory : ICommandHandlerFactory
{
    private readonly ILifetimeScope _scope;

    public CommandHandlerFactory(ILifetimeScope scope)
    {
        _scope = scope;
    }

    public IDictionary<string, ICommandHandler> CreateHandlers()
    {
        return  new Dictionary<string, ICommandHandler>()
        {
            { CommandConstants.Start, new StartCommandHandler() },
            { CommandConstants.Bachelor, new BachelorCommandHandler() },
            { CommandConstants.Master, new MasterCommandHandler() },
            { CommandConstants.B121, new SpecialisationInfoCommandHandler(_scope)},
            { CommandConstants.B122, new SpecialisationInfoCommandHandler(_scope)},
            { CommandConstants.B123, new SpecialisationInfoCommandHandler(_scope)},
            { CommandConstants.M121, new SpecialisationInfoCommandHandler(_scope)},
            { CommandConstants.M122, new SpecialisationInfoCommandHandler(_scope)},
            { CommandConstants.M123, new SpecialisationInfoCommandHandler(_scope)},
            { CommandConstants.Statistics, new StatisticsCommandHandler(_scope)},
        };
    }
}