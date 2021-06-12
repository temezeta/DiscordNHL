using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class TeamsDto
    {
        public string Copyright { get; set; }
        public IList<TeamDto> Teams { get; set; }
    }
}
