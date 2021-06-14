using System.Collections.Generic;

namespace NHLStats.Dtos
{
    public class StandingsDto
    {
        public string Copyright { get; set; }
        public IList<RecordDto> Records { get; set; }
    }
}
