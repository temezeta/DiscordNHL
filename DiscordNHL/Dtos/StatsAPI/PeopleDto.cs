namespace DiscordNHL.Dtos.StatsAPI
{
    public class PeopleDto : PersonDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrimaryNumber { get; set; }
        public string BirthDate { get; set; }
        public int CurrentAge { get; set; }
        public string BirthCity { get; set; }
        public string BirthStateProvince { get; set; }
        public string BirthCountry { get; set; }
        public string Nationality { get; set; }
        public string Height { get; set; }
        public int Weight { get; set; }
        public bool Active { get; set; }
        public bool AlternateCaptain { get; set; }
        public bool Captain { get; set; }
        public bool Rookie { get; set; }
        public string ShootsCatches { get; set; }
        public string RosterStatus { get; set; }
        public TeamDto CurrentTeam { get; set; }
        public PositionDto PrimaryPosition { get; set; }
    }
}
