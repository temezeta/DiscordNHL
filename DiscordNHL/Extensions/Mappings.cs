using DiscordNHL.Dtos.StatsAPI;
using DiscordNHL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DiscordNHL.Extensions
{
    public static class Mappings
    {
        public static EmbedData ToTeamEmbedData(this TeamDto team)
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

        public static EmbedData ToRosterEmbedData(this TeamDto team) 
        {
            var embedData = new EmbedData
            {
                Title = team.Name,
                Description = $"Roster of the {team.TeamName}",
                Url = team.OfficialSiteUrl
            };

            embedData.Data = new List<EmbedValue>();

            if (team.Roster != null) {
                var roster = team.Roster.Roster;

                var playerTypes = roster?
                    .Where(it => it.Person?.FullName != null && it.Position?.Name != null && it.Position?.Type != null)
                    .OrderBy(it => it.Person.FullName)
                    .ThenBy(it => it.Position.Name)
                    .GroupBy(it => it.Position.Type);

                var goalies = playerTypes?.FirstOrDefault(it => it.Key == "Goalie");
                var defense = playerTypes?.FirstOrDefault(it => it.Key == "Defenseman");
                var forwards = playerTypes?.FirstOrDefault(it => it.Key == "Forward");

                var goalieNames = string.Join("\n", goalies?.Select(it => string.Join(", ", it.Person.FullName, GetJerseyNumberString(it.JerseyNumber))));
                embedData.Data.Add(new EmbedValue("Goalies", goalieNames));
                var defenseNames = string.Join("\n", defense?.Select(it => string.Join(", ", it.Person.FullName,  GetJerseyNumberString(it.JerseyNumber))));
                embedData.Data.Add(new EmbedValue("Defensemen", defenseNames));
                var forwardNames = string.Join("\n", forwards?.Select(it => string.Join(", ", it.Person.FullName, it.Position.Name, GetJerseyNumberString(it.JerseyNumber))));
                embedData.Data.Add(new EmbedValue("Forwards", forwardNames));
            }

            if (embedData.Data.Count == 0) 
            {
                embedData.Description = "No active roster players found";
            }

            return embedData;
        }

        private static string GetJerseyNumberString(string jerseyNumber) {
            if(jerseyNumber != null)
            {
                return $"#{jerseyNumber}";
            }

            return null;
        }
    }
}
