using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class RosterDto : LinkAttribute
    {
        public IList<PlayerDto> Roster { get; set; }
    }
}
