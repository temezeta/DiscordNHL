﻿using Discord;
using Discord.Commands;
using NHLStats;
using DiscordNHL.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using NHLStats.Extensions;

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
        public async Task GetTeamByAbbreviation(string abbreviation)
        {
            try
            {
                var id = await StaticNHLDataService.GetTeamIdByAbbreviation(abbreviation);

                var response = await _provider.GetTeamById(id ?? -1);
                var isCommandSuccess = false;

                if (response.IsSuccess) {
                    var team = response.Data.Teams.FirstOrDefault();
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
                    await Context.Channel.SendMessageAsync($"Team with abbreviation {abbreviation} not found");
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync($"An error occured");
            }
        }

        [Command("roster")]
        [Alias("r")]
        public async Task GetTeamRosterByAbbreviation(string abbreviation, string season = null)
        {
            try
            {
                var id = await StaticNHLDataService.GetTeamIdByAbbreviation(abbreviation);

                var response = await _provider.GetFullTeamById(id ?? -1, season);
                var isCommandSuccess = false;

                if (response.IsSuccess)
                {
                    var team = response.Data.Teams.FirstOrDefault();

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
                    await Context.Channel.SendMessageAsync($"Team roster with abbreviation {abbreviation} not found");
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync($"An error occured");
            }
        }

        [Command("stats")]
        [Alias("s")]
        public async Task GetTeamStatsByAbbreviation(string abbreviation, string season = null) 
        {
            try
            {
                var id = await StaticNHLDataService.GetTeamIdByAbbreviation(abbreviation);

                var response = await _provider.GetFullTeamById(id ?? -1, season);
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
                    await Context.Channel.SendMessageAsync($"Team stats with abbreviation {abbreviation} not found");
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync($"An error occured");
            }
        }

        [Command("games")]
        [Alias("g")]
        public async Task GetGames(string abbreviation, string startDate = null, string endDate = null) 
        {
            try
            {
                abbreviation = abbreviation.ToUpper() == "ALL" ? null : abbreviation;

                var id = await StaticNHLDataService.GetTeamIdByAbbreviation(abbreviation);
                var isCommandSuccess = false;
                var teams = id != null ? await _provider.GetTeamById(id.Value) : null;
                var schedule = await _provider.GetSchedule(id, startDate, endDate);

                if (schedule.IsSuccess)
                {
                    var team = teams?.Data?.Teams?.FirstOrDefault();
                    var games = schedule.Data;

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
    }
}
