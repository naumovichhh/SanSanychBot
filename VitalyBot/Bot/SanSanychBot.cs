using System.Collections.Generic;
using System.Configuration;
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
            botClient = new TelegramBotClient(Configuration.GetSection("BotConfig").GetValue<string>("Token"));
        }

        public IConfiguration Configuration { get; set; }

        public void SetWebHook()
        {
            TelegramBotClient botClient = new TelegramBotClient(
                Configuration.GetSection("BotConfig").GetValue<string>("Token")
            );
            string hook = Configuration.GetSection("BotConfig").GetValue<string>("Url") + "/api/update";
            botClient.SetWebhookAsync(hook).Wait();
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
