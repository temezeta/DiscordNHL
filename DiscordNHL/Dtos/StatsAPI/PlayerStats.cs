using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class PlayerStats
    {
        public StatTypeDto Type { get; set; }
        public IList<PlayerStatDto> Splits { get; set; }
    }
}
