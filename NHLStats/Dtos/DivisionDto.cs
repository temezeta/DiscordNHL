namespace NHLStats.Dtos
{
    public class DivisionDto : CommonProperties
    {
        public string Abbreviation { get; set; }
        public ConferenceDto Conference { get; set; }
        public bool? Active { get; set; }


    }
}
