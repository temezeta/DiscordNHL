using Discord.Commands;
using DiscordNHL.Integrations;
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
                var response = await _provider.GetFullTeams();

                if (response.IsSuccess)
                {
                    var team = response.Data.Teams.FirstOrDefault(it => 
                    string.Equals(it.Abbreviation, search, StringComparison.InvariantCultureIgnoreCase) 
                    || 
                    search.Length >= 5 && it.Name.Contains(search, StringComparison.InvariantCultureIgnoreCase)
                    );

                    if (team != null)
                    {
                        // TODO
                        await Context.Channel.SendMessageAsync(team.Name);
                    }
                    else
                    {
                        throw new ArgumentNullException();
                    }
                }
            }
            catch
            {
                await Context.Channel.SendMessageAsync($"Team with search {search} not found");
            }
        }
    }
}
