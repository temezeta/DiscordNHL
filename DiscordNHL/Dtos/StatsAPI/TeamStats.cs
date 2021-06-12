using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class TeamStats
    {
        public StatTypeDto Type { get; set; }
        public IList<StatTeamDto> Splits { get; set; }
    }

    public class StatTeamDto
    {
        public TeamStatDto Stat { get; set; }
        public CommonAttributes Team { get; set; }
    }
}
