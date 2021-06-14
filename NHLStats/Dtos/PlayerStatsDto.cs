using System.Collections.Generic;

namespace NHLStats.Dtos
{
    public class PlayerStatsDto
    {
        public string Copyright { get; set; }
        public IList<PlayerStatDto> Stats { get; set; }
    }
}
