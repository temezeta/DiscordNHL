using Common.Models;
using Common.Services;
using DiscordNHL.Dtos.StatsAPI;
using System.Net.Http;
using System.Threading.Tasks;

namespace DiscordNHL.Integrations
{
    public class NHLDataProvider : BaseApiClient, INHLDataProvider
    {
        public NHLDataProvider(HttpClient client) : base(client) { }

        public async Task<ApiResponse<ConferencesDto>> GetConferences()
        {
            return await GetAsync<ConferencesDto>("conferences");
        }

        public async Task<ApiResponse<TeamsDto>> GetTeams()
        {
            return await GetAsync<TeamsDto>("teams");
        }

        public async Task<ApiResponse<TeamsDto>> GetTeamById(int id)
        {
            return await GetAsync<TeamsDto>($"teams/{id}");
        }

        public async Task<ApiResponse<TeamsDto>> GetFullTeams()
        {
            return await GetAsync<TeamsDto>("teams?expand=team.schedule.next,team.schedule.previous,team.roster,team.stats");
        }

        public async Task<ApiResponse<TeamsDto>> GetFullTeamById(int id)
        {
            return await GetAsync<TeamsDto>($"teams/{id}?expand=team.schedule.next,team.schedule.previous,team.roster,team.stats");
        }
    }
}
