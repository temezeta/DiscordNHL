﻿using Common.Models;
using Common.Services;
using NHLStats.Dtos;
using NHLStats.Helpers;
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

        public async Task<ApiResponse<TeamsDto>> GetFullTeamById(int id, string season = null)
        {
            var url = $"teams/{id}?expand=team.schedule.next,team.schedule.previous,team.roster,team.stats";

            if (season != null) 
            {
                url += $"&season={SeasonYearHelper.Trim(season)}";
            }

            return await GetAsync<TeamsDto>(url);
        }

        public async Task<ApiResponse<GameScheduleDto>> GetSchedule(int? teamId = null, string startDate = null, string endDate = null) 
        {
            var builder = new StringBuilder("schedule?");

            var query = string.Join("&",
                teamId != null ? $"teamId={teamId}" : null,
                startDate != null ? $"startDate={startDate}" : null,
                endDate != null ? $"endDate={endDate}" : null);

            builder.Append(query);

            return await GetAsync<GameScheduleDto>(builder.ToString());
        }

    }
}
