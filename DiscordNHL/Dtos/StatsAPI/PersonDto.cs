namespace DiscordNHL.Dtos.StatsAPI
{
    public class PersonDto : LinkAttribute
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
