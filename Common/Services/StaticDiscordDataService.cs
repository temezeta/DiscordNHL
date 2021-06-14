using Discord.WebSocket;

namespace Common.Services
{
    public class StaticDiscordDataService
    {
        private static DiscordSocketClient Discord;
        public static string BotAvatarUrl => Discord.CurrentUser.GetAvatarUrl() ?? Discord.CurrentUser.GetDefaultAvatarUrl();

        public StaticDiscordDataService(DiscordSocketClient discord) 
        {
            Discord = discord;
        }
    }
}
