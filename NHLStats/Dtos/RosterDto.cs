using System.Collections.Generic;

namespace NHLStats.Dtos
{
    public class RosterDto : LinkProperty
    {
        public IList<PlayerDto> Roster { get; set; }
    }
}
