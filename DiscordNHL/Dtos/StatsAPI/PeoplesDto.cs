using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class PeoplesDto
    {
        public string Copyright { get; set; }
        public IList<PeopleDto> People { get; set; }
    }
}
