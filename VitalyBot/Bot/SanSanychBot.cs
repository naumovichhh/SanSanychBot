using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace VitalyBot.Bot
{
    public class SanSanychBot
    {
        private TelegramBotClient botClient;
        private List<ICommand> commands = new List<ICommand>();

        public SanSanychBot(IConfiguration configuration)
        {
            Configuration = configuration;
            commands.Add(new StartCommand());
            commands.Add(new ProbabilityCommand());
            string token = Configuration.GetSection("BotConfig").GetValue<string>("Token");
            botClient = new TelegramBotClient(token);
        }

        public IConfiguration Configuration { get; set; }

        public async Task<WebhookInfo> GetWebhookAsync()
        {
            return await botClient.GetWebhookInfoAsync();
        }

        public async Task Execute(Message message)
        {
            foreach (var command in commands)
            {
                if (command.Contained(message))
                {
                    await command.Execute(message, botClient);
                }
            }
        }
    }
}
