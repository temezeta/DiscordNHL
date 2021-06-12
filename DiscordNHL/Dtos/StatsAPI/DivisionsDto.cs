using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class DivisionsDto
    {
        public string Copyright { get; set; }
        public IList<DivisionDto> Divisions { get; set;}
    }
}
