namespace DiscordNHL.Dtos.StatsAPI
{
    public class StatusDto
    {
        public string AbstractGameState { get; set; }
        public string CodedGameState { get; set; }
        public string DetailedState { get; set; }
        public string StatusCode { get; set; }
        public bool StartTimeTBD { get; set; }
    }
}
