using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class TeamStatsDto
    {
        public string Copyright { get; set; }
        public IList<TeamStatisticsDto> Stats { get; set; }
    }
}
