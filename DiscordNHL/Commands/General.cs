using Discord.Commands;
using DiscordNHL.Services;
using System.Threading.Tasks;

namespace DiscordNHL.Commands
{
    public class General : ModuleBase
    {
        public General()
        {
        }
        [Command("favourite")]
        [Alias("f")]
        public async Task Favourite(string searchString = null)
        {
            if (searchString == null)
            {
                var teamName = StaticNHLDataService.GetFavouriteTeamName();

                if (teamName == null)
                {
                    await Context.Channel.SendMessageAsync("Favourite team not found");
                }
                else
                {
                    await Context.Channel.SendMessageAsync($"Your favourite team is {teamName}");
                }
            }
            else
            {
                var teamName = await StaticNHLDataService.SetFavoriteTeam(searchString);

                if (teamName == null)
                {
                    await Context.Channel.SendMessageAsync($"Team not found with string {searchString}");
                }
                else 
                {
                    await Context.Channel.SendMessageAsync($"Team {teamName} has been added as favourite team");

                }
            }

        }
    }
}
