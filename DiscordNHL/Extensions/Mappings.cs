using DiscordNHL.Dtos.StatsAPI;
using DiscordNHL.Models;
using System.Collections.Generic;

namespace DiscordNHL.Extensions
{
    public static class Mappings
    {
        public static EmbedData ToEmbedData(this TeamDto team)
        {
            var embedData = new EmbedData
            {
                Title = team.Name,
                Description = $"Information about the {team.TeamName}",
                Url = team.OfficialSiteUrl
            };

            embedData.Data = new List<EmbedValue>(){
                new EmbedValue("Abbreviation", team.Abbreviation),
                new EmbedValue("Location", team.LocationName),
                new EmbedValue("Venue", team.Venue?.Name, true),
                new EmbedValue("Location", team.Venue?.City, true),
                new EmbedValue("Founded in", team.FirstYearOfPlay),
                new EmbedValue("Conference", team.Conference?.Name),
                new EmbedValue("Division", team.Division?.Name),
                new EmbedValue("Activity status", team.Active == true ? "Active" : "Inactive")
            };

            return embedData;
        }
    }
}
