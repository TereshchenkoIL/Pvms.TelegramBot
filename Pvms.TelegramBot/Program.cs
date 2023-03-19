// See https://aka.ms/new-console-template for more information

using Autofac;
using Pvms.TelegramBot;
using Pvms.TelegramBot.MessageHandler;
using Telegram.Bot;
using Telegram.Bot.Polling;


var cts = new CancellationTokenSource();
var cancellationToken = cts.Token;
var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = { }, // receive all update types
};

Console.WriteLine("Запущен бот " + BotWrapper.BotClient.GetMeAsync().Result.FirstName);

BotWrapper.StartReceiving(receiverOptions, cancellationToken);
Console.ReadLine();