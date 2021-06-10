using Discord.Commands;
using DiscordNHL.Integrations;
using System.Threading.Tasks;

namespace DiscordNHL.Commands
{
    public class General : ModuleBase
    {
        public readonly INHLDataProvider _provider;
        public General(INHLDataProvider provider)
        {
            _provider = provider;
        }
        [Command("ping")]
        public async Task Ping()
        {
            await Context.Channel.SendMessageAsync("Pong");
        }
    }
}
