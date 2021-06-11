using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class ConferencesDto
    {
        public string Copyright { get; set; }
        public IList<ConferenceDto> Conferences { get; set; }
    }
}
