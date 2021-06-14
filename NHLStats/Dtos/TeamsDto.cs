using System.Collections.Generic;

namespace NHLStats.Dtos
{
    public class TeamsDto
    {
        public string Copyright { get; set; }
        public IList<TeamDto> Teams { get; set; }
    }
}
