using Discord;
using Discord.Commands;
using DiscordNHL.Dtos.StatsAPI;
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

                if (response.IsSuccess) {
                    var team = response.Data.Teams.FirstOrDefault();

                    if (team != null)
                    {

                        var embed = new EmbedBuilder()
                            .AddGeneralFields(CommandHandler.Discord)
                            .AddNHLDataFields(team.ToTeamEmbedData())
                            .Build();

                        await Context.Channel.SendMessageAsync(null, false, embed);
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync($"Team with search {abbreviation} not found");
                    }
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync($"An error occured");
            }
        }

        [Command("roster")]
        public async Task GetTeamRosterByAbbreviation(string abbreviation)
        {
            try
            {
                var id = await GetTeamIdByAbbreviation(abbreviation);

                var response = await _provider.GetFullTeamById(id);

                if (response.IsSuccess)
                {
                    var team = response.Data.Teams.FirstOrDefault();

                    if (team != null)
                    {

                        var embed = new EmbedBuilder()
                            .AddGeneralFields(CommandHandler.Discord)
                            .AddNHLDataFields(team.ToRosterEmbedData())
                            .Build();

                        await Context.Channel.SendMessageAsync(null, false, embed);
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync($"Team roster with search {abbreviation} not found");
                    }
                }
            }
            catch (Exception ex)
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
