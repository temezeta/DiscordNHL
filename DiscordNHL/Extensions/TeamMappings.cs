using DiscordNHL.Dtos.StatsAPI;
using DiscordNHL.Helpers;
using DiscordNHL.Models;
using System.Collections.Generic;
using System.Linq;

namespace DiscordNHL.Extensions
{
    public static class TeamMappings
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

        public static EmbedData ToRosterEmbedData(this TeamDto team, string season = null) 
        {
            var realSeason = SeasonYearHelper.Trim(season);

            var embedData = new EmbedData
            {
                Title = team.Name,
                Description = string.Join(" ",$"Roster of the {team.TeamName}", realSeason != null ? $"for season {SeasonYearHelper.ToLongForm(realSeason)}" : "for current season"),
                Url = team.OfficialSiteUrl
            };

            embedData.Data = new List<EmbedValue>();

            if (team.Roster != null) {
                var roster = team.Roster.Roster;

                var playerTypes = roster?
                    .Where(it => it.Person?.FullName != null && it.Position?.Abbreviation != null && it.Position?.Type != null)
                    .OrderBy(it => it.Position.Abbreviation)
                    .ThenBy(it => it.Person.FullName)
                    .GroupBy(it => it.Position.Type);

                var goalies = playerTypes?.FirstOrDefault(it => it.Key == "Goalie");
                var defense = playerTypes?.FirstOrDefault(it => it.Key == "Defenseman");
                var forwards = playerTypes?.FirstOrDefault(it => it.Key == "Forward");

                var goalieNames = string.Join("\n", goalies?.Select(it => string.Join(", ", it.Person.FullName, GetJerseyNumberString(it.JerseyNumber))));
                embedData.Data.Add(new EmbedValue("Goalies", goalieNames));
                var defenseNames = string.Join("\n", defense?.Select(it => string.Join(", ", it.Person.FullName,  GetJerseyNumberString(it.JerseyNumber))));
                embedData.Data.Add(new EmbedValue("Defensemen", defenseNames));
                var forwardNames = string.Join("\n", forwards?.Select(it => string.Join(", ", it.Person.FullName, it.Position.Abbreviation, GetJerseyNumberString(it.JerseyNumber))));
                embedData.Data.Add(new EmbedValue("Forwards", forwardNames));
            }

            if (embedData.Data.Count == 0) 
            {
                embedData.Description = "No active roster players found";
            }

            return embedData;
        }

        public static EmbedData ToStatsEmbedData(this TeamDto team, string season = null) 
        {
            var realSeason = SeasonYearHelper.Trim(season);

            var embedData = new EmbedData
            {
                Title = team.Name,
                Description = string.Join(" ", $"Stats of the {team.TeamName}", realSeason != null ? $"for season {SeasonYearHelper.ToLongForm(realSeason)}" : "for current season"),
                Url = team.OfficialSiteUrl
            };

            embedData.Data = new List<EmbedValue>();

            if (team.TeamStats != null)
            {
                var regSeasonStats = team.TeamStats.FirstOrDefault(it => it.Type?.GameType?.Id == "R");

                if (regSeasonStats?.Splits?.Count != 0) 
                {
                    var stats = regSeasonStats.Splits.FirstOrDefault().Stat;

                    embedData.Data = new List<EmbedValue>
                    {
                        new EmbedValue("Games played", stats.GamesPlayed),
                        new EmbedValue("Wins", stats.Wins),
                        new EmbedValue("Losses", stats.Losses),
                        new EmbedValue("OT losses", stats.Ot),
                        new EmbedValue("Points", stats.Pts),
                        new EmbedValue("Goals for avg", stats.GoalsPerGame),
                        new EmbedValue("Goals against avg", stats.GoalsAgainstPerGame),
                        new EmbedValue("Save percentage", (stats.SavePctg * 100)?.ToString("#.#")),
                        new EmbedValue("PP Percentage", stats.PowerPlayPercentage),
                        new EmbedValue("PK Percentage", stats.PenaltyKillPercentage),
                    };

                }
            }

            if (embedData.Data?.Count == 0)
            {
                embedData.Description = "No stats found";
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
