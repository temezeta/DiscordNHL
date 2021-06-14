using System.Collections.Generic;

namespace NHLStats.Dtos
{
    public class ConferencesDto
    {
        public string Copyright { get; set; }
        public IList<ConferenceDto> Conferences { get; set; }
    }
}
