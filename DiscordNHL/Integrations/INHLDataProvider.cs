using Common.Models;
using DiscordNHL.Dtos.StatsAPI;
using System.Threading.Tasks;

namespace DiscordNHL.Integrations
{
    public interface INHLDataProvider
    {
        Task<ApiResponse<ConferencesDto>> GetConferences();
    }
}