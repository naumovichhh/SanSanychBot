using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using VitalyBot.Bot;

namespace VitalyBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateController : ControllerBase
    {
        private SanSanychBot bot;

        public UpdateController(SanSanychBot bot)
        {
            this.bot = bot;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Update update)
        {
            if (update == null)
                return Ok();

            var message = update.Message;
            await bot.Execute(message);
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("OHSHITMANGODDAMNSON");
        }
    }
}
