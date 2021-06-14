using NHLStats;
using NHLStats.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordNHL.Services
{
    public class StaticNHLDataService
    {
        private static IDictionary<string, int> TeamIdByAbbreviation;
        private static INHLDataProvider _provider;

        public StaticNHLDataService(INHLDataProvider provider) 
        {
            _provider = provider;
        }

        public static async Task<IDictionary<string, int>> GetTeamIds()
        {
            if (TeamIdByAbbreviation == null)
            {
                var response = await _provider.GetTeams();

                if (response.IsSuccess)
                {
                    var teamResponse = response.Data;

                    if (teamResponse != null && teamResponse.Teams != null)
                    {
                        TeamIdByAbbreviation = new Dictionary<string, int>();
                        foreach (var team in teamResponse.Teams)
                        {
                            TeamIdByAbbreviation.Add(team.Abbreviation, team.Id);
                        }
                    }
                }
            }
            return TeamIdByAbbreviation;
        }

        public static async Task<int?> GetTeamIdByAbbreviation(string abbreviation) 
        {
            if (abbreviation == null) 
            {
                return null;
            }

            abbreviation = abbreviation.ToUpper();

            var teamIds = await GetTeamIds();

            if (teamIds.TryGetValue(abbreviation, out int teamId))
            {
                return teamId;
            }
            else
            {
                return null;
            }
        }
    }
}
