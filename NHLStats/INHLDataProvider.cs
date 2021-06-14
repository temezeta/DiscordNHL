using Common.Models;
using NHLStats.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NHLStats
{
    public interface INHLDataProvider
    {
        Task<ApiResponse<ConferencesDto>> GetConferences();
        Task<ApiResponse<TeamsDto>> GetTeams(IList<QueryData> queries = null);
        Task<ApiResponse<TeamsDto>> GetTeamById(int? id, IList<QueryData> queries = null);
        Task<ApiResponse<GameScheduleDto>> GetSchedule(IList<QueryData> queries = null);
        Task<ApiResponse<StandingsDto>> GetStandings(IList<QueryData> queries = null);
    }
}