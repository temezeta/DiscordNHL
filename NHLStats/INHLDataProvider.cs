using Common.Models;
using NHLStats.Dtos;
using System.Threading.Tasks;

namespace NHLStats
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