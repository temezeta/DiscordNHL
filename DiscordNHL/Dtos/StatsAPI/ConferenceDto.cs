﻿namespace DiscordNHL.Dtos.StatsAPI
{
    public class ConferenceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public string Abbreviation { get; set; }
        public string ShortName { get; set; }
        public bool Active { get; set; }
    }
}