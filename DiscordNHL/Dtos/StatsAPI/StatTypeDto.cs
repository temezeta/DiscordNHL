namespace DiscordNHL.Dtos.StatsAPI
{
    public class StatTypeDto
    {
        public string DisplayName { get; set; }
        public GameTypeDto GameType { get; set; }
    }

    public class GameTypeDto
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public bool Postseason { get; set; }
    }
}
