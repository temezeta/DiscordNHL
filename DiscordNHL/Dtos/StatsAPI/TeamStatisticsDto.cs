using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class TeamStatisticsDto
    {
        public StatTypeDto Type { get; set; }
        public IList<StatTeamDto> Splits { get; set; }
    }

    public class StatTeamDto
    {
        public TeamStatDto Stat { get; set; }
        public CommonProperties Team { get; set; }
    }
}
