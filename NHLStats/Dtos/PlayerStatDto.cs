namespace NHLStats.Dtos
{
    public class PlayerStatDto
    {
        public string Season { get; set; }
        public StatDto Stat { get; set; }
    }

    public class StatDto
    {
        public string TimeOnIce { get; set; }
        public int Assists { get; set; }
        public int Goals { get; set; }
        public int Pim { get; set; }
        public int Shots { get; set; }
        public int Games { get; set; }
        public int Hits { get; set; }
        public int PowerPlayGoals { get; set; }
        public int PowerPlayPoints { get; set; }
        public string PowerPlayTimeOnIce { get; set; }
        public string EvenTimeOnIce { get; set; }
        public string PenaltyMinutes { get; set; }
        public decimal FaceOffPct { get; set; }
        public decimal ShotPct { get; set; }
        public int GameWinningGoals { get; set; }
        public int OverTimeGoals { get; set; }
        public int ShortHandedGoals { get; set; }
        public int ShortHandedPoints { get; set; }
        public string ShortHandedTimeOnIce { get; set; }
        public int Blocked { get; set; }
        public int PlusMinus { get; set; }
        public int Points { get; set; }
        public int Shifts { get; set; }
        public string TimeOnIcePerGame { get; set; }
        public string EvenTimeOnIcePerGame { get; set; }
        public string ShortHandedTimeOnIcePerGame { get; set; }
        public string PowerPlayTimeOnIcePerGame { get; set; }
    }
}
