using System.Collections.Generic;

namespace NHLStats.Dtos
{
    public class TeamStatsDto
    {
        public string Copyright { get; set; }
        public IList<TeamStatisticsDto> Stats { get; set; }
    }
}
