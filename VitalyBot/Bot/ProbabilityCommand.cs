using System;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace VitalyBot.Bot
{
    public class ProbabilityCommand : ICommand
    {
        public string Name => "/info";

        public bool Contained(Message message)
        {
            if (message.Type != Telegram.Bot.Types.Enums.MessageType.Text)
            {
                return false;
            }

            return message.Text.Contains(Name);
        }

        public async Task Execute(Message message, TelegramBotClient botClient)
        {
            long chatId = message.Chat.Id;
            await botClient.SendTextMessageAsync(chatId, $"Инфа - {new Random().Next(101)}%");
        }
    }
}
