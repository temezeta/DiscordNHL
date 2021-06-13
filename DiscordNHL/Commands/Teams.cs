using Discord;
using Discord.Commands;
using DiscordNHL.Extensions;
using DiscordNHL.Integrations;
using DiscordNHL.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

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
                var id = await GetTeamIdByAbbreviation(abbreviation);

                var response = await _provider.GetTeamById(id);
                var isCommandSuccess = false;

                if (response.IsSuccess) {
                    var team = response.Data.Teams.FirstOrDefault();

                    if (team != null)
                    {

                        var embed = new EmbedBuilder()
                            .AddGeneralFields(CommandHandler.Discord)
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
                var id = await GetTeamIdByAbbreviation(abbreviation);

                var response = await _provider.GetFullTeamById(id, season);
                var isCommandSuccess = false;

                if (response.IsSuccess)
                {
                    var team = response.Data.Teams.FirstOrDefault();

                    if (team != null)
                    {

                        var embed = new EmbedBuilder()
                            .AddGeneralFields(CommandHandler.Discord)
                            .AddNHLDataFields(team.ToRosterEmbedData())
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
                var id = await GetTeamIdByAbbreviation(abbreviation);

                var response = await _provider.GetFullTeamById(id, season);
                var isCommandSuccess = false;

                if (response.IsSuccess)
                {
                    var team = response.Data.Teams.FirstOrDefault();

                    if (team != null)
                    {

                        var embed = new EmbedBuilder()
                            .AddGeneralFields(CommandHandler.Discord)
                            .AddNHLDataFields(team.ToStatsEmbedData())
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

        private async Task<int> GetTeamIdByAbbreviation(string abbreviation) {
            var abbrev = abbreviation.ToUpper();

            if (StaticDataService.TeamIdByAbbreviation == null)
            {
                var response = await _provider.GetTeams();

                if (response.IsSuccess)
                {
                    StaticDataService.SetTeamIds(response.Data);
                } 
                else
                {
                    throw new ArgumentNullException();
                }
            }


            if (StaticDataService.TeamIdByAbbreviation.TryGetValue(abbrev, out int teamId))
            {
                return teamId;
            }
            else
            {
                return -1;
            }
        }
    }
}
