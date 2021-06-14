using Common.Models;
using Common.Services;
using NHLStats.Dtos;
using NHLStats.Helpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NHLStats
{
    public class NHLDataProvider : BaseApiClient, INHLDataProvider
    {
        public NHLDataProvider(HttpClient client) : base(client) { }

        public async Task<ApiResponse<ConferencesDto>> GetConferences()
        {
            return await GetAsync<ConferencesDto>("conferences");
        }

        public async Task<ApiResponse<TeamsDto>> GetTeams(IList<QueryData> queries = null)
        {
            return await GetAsync<TeamsDto>(BuildUrl("teams", queries));
        }

        public async Task<ApiResponse<TeamsDto>> GetTeamById(int? id, IList<QueryData> queries = null)
        {
            if (id == null)
            {
                return null;
            }

            return await GetAsync<TeamsDto>(BuildUrl($"teams/{id}", queries));
        }

        public async Task<ApiResponse<GameScheduleDto>> GetSchedule(IList<QueryData> queries = null) 
        {
            return await GetAsync<GameScheduleDto>(BuildUrl("schedule", queries));
        }

    }
}
