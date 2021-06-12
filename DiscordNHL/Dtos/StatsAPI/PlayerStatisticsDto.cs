using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class PlayerStatisticsDto
    {
        public StatTypeDto Type { get; set; }
        public IList<PlayerStatDto> Splits { get; set; }
    }
}
