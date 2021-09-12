using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace VitalyBot.Bot
{
    interface ICommand
    {
        string Name { get; }
        Task Execute(Message message, TelegramBotClient botClient);
        bool Contained(Message message);
    }
}
