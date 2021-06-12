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
        public async Task GetTeamBySearchString(string search)
        {
            try
            {
                var response = await _provider.GetTeams();

                if (response.IsSuccess)
                {
                    var team = response.Data.Teams.FirstOrDefault(it => 
                    string.Equals(it.Abbreviation, search, StringComparison.InvariantCultureIgnoreCase) 
                    || 
                    search.Length >= 5 && it.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    );

                    if (team != null)
                    {

                        var embed = new EmbedBuilder()
                            .AddGeneralFields(CommandHandler.Discord)
                            .AddNHLDataFields(team.ToEmbedData())
                            .Build();

                        await Context.Channel.SendMessageAsync(null, false, embed);
                    }
                    else
                    {
                        await Context.Channel.SendMessageAsync($"Team with search {search} not found");
                    }
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync($"An error occured");
            }
        }
    }
}
