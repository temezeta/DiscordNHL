namespace DiscordNHL.Dtos.StatsAPI
{
    public class PlayerDto
    {
        public PersonDto Person { get; set; }
        public string JerseyNumber { get; set; }
        public PositionDto Position { get; set; }
    }
}
