namespace DiscordNHL.Dtos.StatsAPI
{
    public class VenueDto : CommonAttributes
    {
        public string City { get; set; }
        public TimeZoneDto TimeZone { get; set; }
    }
}
