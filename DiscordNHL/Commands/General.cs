using Discord.Commands;
using System.Threading.Tasks;

namespace DiscordNHL.Commands
{
    public class General : ModuleBase
    {
        public General()
        {
        }
        [Command("ping")]
        public async Task Ping()
        {
            await Context.Channel.SendMessageAsync("Pong");
        }
    }
}
