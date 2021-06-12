﻿namespace DiscordNHL.Dtos.StatsAPI
{
    public class ConferenceDto : CommonProperties
    {
        public string Abbreviation { get; set; }
        public string ShortName { get; set; }
        public bool? Active { get; set; }
    }
}
