using System.Collections.Generic;

namespace NHLStats.Dtos
{
    public class PlayerStatisticsDto
    {
        public StatTypeDto Type { get; set; }
        public IList<PlayerStatDto> Splits { get; set; }
    }
}
