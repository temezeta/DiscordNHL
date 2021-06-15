using Discord;
using Discord.Commands;
using NHLStats;
using DiscordNHL.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using NHLStats.Extensions;
using System.Collections.Generic;
using Common.Models;
using NHLStats.Helpers;

namespace DiscordNHL.Commands
{
    [Group("teams")]
    public class Teams : ModuleBase
    {
        public readonly INHLDataProvider _provider;
        public Teams(INHLDataProvider provider)
        {
            _provider = provider;
        }
        [Command("")]
        public async Task GetTeamBySearchString(string searchString)
        {
            try
            {
                var id = await StaticNHLDataService.GetTeamIdBySearchString(searchString);

                var response = await _provider.GetTeamById(id);

                var isCommandSuccess = false;

                if (response.IsSuccess) {
                    var team = response.Data?.Teams?.FirstOrDefault();

                    if (team != null)
                    {

                        var embed = new EmbedBuilder()
                            .AddGeneralFields()
                            .AddNHLDataFields(team.ToTeamEmbedData())
                            .Build();

                        isCommandSuccess = true;
                        await Context.Channel.SendMessageAsync(null, false, embed);
                    }
                }
                if(!isCommandSuccess)
                {
                    await Context.Channel.SendMessageAsync($"Team with search {searchString} not found");
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync($"An error occured");
            }
        }

        [Command("roster")]
        [Alias("r")]
        public async Task GetTeamRosterBySearchString(string searchString, string season = null)
        {
            try
            {
                var id = await StaticNHLDataService.GetTeamIdBySearchString(searchString);

                var response = await _provider.GetTeamById(id, new List<QueryData>
                {
                    new QueryData("expand", "team.roster"),
                    new QueryData("season", SeasonYearHelper.Trim(season))
                });

                var isCommandSuccess = false;

                if (response.IsSuccess)
                {
                    var team = response.Data?.Teams?.FirstOrDefault();

                    if (team != null)
                    {

                        var embed = new EmbedBuilder()
                            .AddGeneralFields()
                            .AddNHLDataFields(team.ToRosterEmbedData(season))
                            .Build();

                        isCommandSuccess = true;
                        await Context.Channel.SendMessageAsync(null, false, embed);
                    } 
                }

                if (!isCommandSuccess) 
                {
                    await Context.Channel.SendMessageAsync($"Team roster with search {searchString} not found");
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync($"An error occured");
            }
        }

        [Command("stats")]
        [Alias("s")]
        public async Task GetTeamStatsBySearchString(string searchString, string season = null) 
        {
            try
            {
                var id = await StaticNHLDataService.GetTeamIdBySearchString(searchString);

                var response = await _provider.GetTeamById(id, new List<QueryData>
                {
                    new QueryData("expand", "team.stats"),
                    new QueryData("season", SeasonYearHelper.Trim(season))
                });

                var isCommandSuccess = false;

                if (response.IsSuccess)
                {
                    var team = response.Data.Teams.FirstOrDefault();

                    if (team != null)
                    {

                        var embed = new EmbedBuilder()
                            .AddGeneralFields()
                            .AddNHLDataFields(team.ToStatsEmbedData(season))
                            .Build();

                        isCommandSuccess = true;
                        await Context.Channel.SendMessageAsync(null, false, embed);
                    }
                }
                if(!isCommandSuccess)
                {
                    await Context.Channel.SendMessageAsync($"Team stats with search {searchString} not found");
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync($"An error occured");
            }
        }

        [Command("games")]
        [Alias("g")]
        public async Task GetGames(string searchString, string startDate = null, string endDate = null) 
        {
            try
            {
                searchString = searchString.ToUpper() == "ALL" ? null : searchString;

                var id = await StaticNHLDataService.GetTeamIdBySearchString(searchString);

                var isCommandSuccess = false;

                var teams = await _provider.GetTeamById(id);

                var response = await _provider.GetSchedule(new List<QueryData>
                {
                    new QueryData("teamId", id),
                    new QueryData("startDate", startDate),
                    new QueryData("endDate", endDate)
                });

                if (response.IsSuccess)
                {
                    var team = teams?.Data?.Teams?.FirstOrDefault();
                    var games = response.Data;

                    var embed = new EmbedBuilder()
                        .AddGeneralFields()
                        .AddNHLDataFields(games.ToGamesEmbedData(team))
                        .Build();

                    isCommandSuccess = true;
                    await Context.Channel.SendMessageAsync(null, false, embed);
                }
                if (!isCommandSuccess)
                {
                    await Context.Channel.SendMessageAsync($"Schedule not found");
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync($"An error occured");
            }
        }

        [Command("standings")]
        [Alias("st")]
        public async Task GetStandings(string season = null)
        {
            try
            {
                var isCommandSuccess = false;

                var response  = await _provider.GetStandings(new List<QueryData>
                {
                    new QueryData("season", SeasonYearHelper.Trim(season))
                });

                if (response.IsSuccess)
                {
                    var embed = new EmbedBuilder()
                        .AddGeneralFields()
                        .AddNHLDataFields(response.Data?.ToStandingsEmbedData(season))
                        .Build();

                    isCommandSuccess = true;
                    await Context.Channel.SendMessageAsync(null, false, embed);
                }
                if (!isCommandSuccess)
                {
                    await Context.Channel.SendMessageAsync($"Standings not found");
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync($"An error occured");
            }
        }
    }
}
