using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class GameScheduleDto
    {
        public int TotalItems { get; set; }
        public int TotalEvent { get; set; }
        public int TotalGames { get; set; }
        public int TotalMatches { get; set; }
        public MetadataProperty MetaData { get; set; }
        public IList<DateDto> Dates { get; set; }

    }
}
