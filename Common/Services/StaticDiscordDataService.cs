namespace Common.Services
{
    public static class StaticDiscordDataService
    {
        public static string BotAvatarUrl;

        public static void SetBotAvatarUrl(string url) 
        {
            BotAvatarUrl = url;
        }
    }
}
