namespace DiscordNHL.Dtos.StatsAPI
{
    public class GameTeamDto
    {
        public LeagueRecordDto LeagueRecord { get; set; }
        public int Score { get; set; }
        public CommonProperties Team { get; set; }
    }
}
