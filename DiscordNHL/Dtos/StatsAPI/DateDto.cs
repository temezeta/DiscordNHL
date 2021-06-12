using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class DateDto
    {
        public string Date { get; set; }
        public int TotalItems { get; set; }
        public int TotalEvent { get; set; }
        public int TotalGames { get; set; }
        public int TotalMatches { get; set; }
        public IList<GameDto> Games { get; set; }
        public IList<EventDto> Events { get; set; }
        public IList<MatchDto> Matches { get; set; }

    }
}
