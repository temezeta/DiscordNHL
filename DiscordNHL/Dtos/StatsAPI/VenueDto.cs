namespace DiscordNHL.Dtos.StatsAPI
{
    public class VenueDto : CommonProperties
    {
        public string City { get; set; }
        public TimeZoneDto TimeZone { get; set; }
    }
}
