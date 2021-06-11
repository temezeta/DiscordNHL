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
    }
}
