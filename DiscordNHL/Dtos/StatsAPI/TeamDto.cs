using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class TeamDto : CommonProperties
    {
        public VenueDto Venue { get; set; }
        public string Abbreviation { get; set; }
        public string TeamName { get; set; }
        public string LocationName { get; set; }
        public string FirstYearOfPlay { get; set; }
        public DivisionDto Division { get; set; }
        public ConferenceDto Conference { get; set; }
        public FranchiseDto Franchise { get; set; }
        public IList<TeamStatisticsDto> TeamStats { get; set; }
        public GameScheduleDto NextGameSchedule { get; set; }
        public GameScheduleDto PreviousGameSchedule { get; set; }
        public RosterDto Roster { get; set; }
        public string ShortName { get; set; }
        public string OfficialSiteUrl { get; set; }
        public int? FranchiseId { get; set; }
        public bool? Active { get; set; }

    }
}
