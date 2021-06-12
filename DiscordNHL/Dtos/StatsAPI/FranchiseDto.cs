namespace DiscordNHL.Dtos.StatsAPI
{
    public class FranchiseDto : LinkProperty
    {
        public int FranchiseId { get; set; }
        public int? FirstSeasonId { get; set; }
        public int? MostRecentTeamId { get; set; }
        public string TeamName { get; set; }
        public string LocationName { get; set; }
    }
}
