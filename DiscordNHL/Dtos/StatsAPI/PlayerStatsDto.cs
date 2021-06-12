using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class PlayerStatsDto
    {
        public string Copyright { get; set; }
        public IList<PlayerStatDto> Stats { get; set; }
    }
}
