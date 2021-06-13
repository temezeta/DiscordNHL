using Common.Models;
using DiscordNHL.Dtos.StatsAPI;
using System.Threading.Tasks;

namespace DiscordNHL.Integrations
{
    public interface INHLDataProvider
    {
        Task<ApiResponse<ConferencesDto>> GetConferences();
        Task<ApiResponse<TeamsDto>> GetTeams();
        Task<ApiResponse<TeamsDto>> GetTeamById(int id);
        Task<ApiResponse<TeamsDto>> GetFullTeams();
        Task<ApiResponse<TeamsDto>> GetFullTeamById(int id, string season = null);
    }
}