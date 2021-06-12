namespace DiscordNHL.Dtos.StatsAPI
{
    public class TeamStatDto
    {
        public int? GamesPlayed { get; set; }
        public string Wins { get; set; }
        public string Losses { get; set; }
        public string Ot { get; set; }
        public string Pts { get; set; }
        public string PtPctg { get; set; }
        public string GoalsPerGame { get; set; }
        public string GoalsAgainstPerGame { get; set; }
        public string EvGGARatio { get; set; }
        public string PowerPlayPercentage { get; set; }
        public string PowerPlayGoals { get; set; }
        public string PowerPlayGoalsAgainst { get; set; }
        public string PowerPlayOpportunities { get; set; }
        public string PenaltyKillPercentage { get; set; }
        public string ShotsPerGame { get; set; }
        public string ShotsAllowed { get; set; }
        public string WinScoreFirst { get; set; }
        public string WinOppScoreFirst { get; set; }
        public string WinLeadFirstPer { get; set; }
        public string WinLeadSecondPer { get; set; }
        public string WinOutshootOpp { get; set; }
        public string WinOutshotByOpp { get; set; }
        public string FaceOffsTaken { get; set; }
        public string FaceOffsWon { get; set; }
        public string FaceOffsLost { get; set; }
        public string FaceOffWinPercentage { get; set; }
        public decimal? ShootingPctg { get; set; }
        public decimal? SavePctg { get; set; }
        public string SavePctRank { get; set; }
        public string ShootingPctRank { get; set; }

    }
}
