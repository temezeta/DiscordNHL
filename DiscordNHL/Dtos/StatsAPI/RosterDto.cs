using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class RosterDto : LinkProperty
    {
        public IList<PlayerDto> Roster { get; set; }
    }
}
