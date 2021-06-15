using Common.Helpers;
using NHLStats;
using NHLStats.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscordNHL.Services
{
    public class StaticNHLDataService
    {
        private static IList<CacheData> TeamIdByAbbreviation;
        private static INHLDataProvider _provider;

        public StaticNHLDataService(INHLDataProvider provider) 
        {
            _provider = provider;
        }

        public static async Task<IList<CacheData>> GetTeams()
        {
            if (TeamIdByAbbreviation == null)
            {
                var response = await _provider.GetTeams();

                if (response.IsSuccess)
                {
                    var teamResponse = response.Data;

                    if (teamResponse != null && teamResponse.Teams != null)
                    {
                        TeamIdByAbbreviation = new List<CacheData>();
                        foreach (var team in teamResponse.Teams)
                        {
                            TeamIdByAbbreviation.Add(new CacheData 
                            {
                                Id = team.Id,
                                Abbreviation = team.Abbreviation,
                                Name = team.Name
                            });
                        }
                    }
                }
            }
            return TeamIdByAbbreviation;
        }

        public static async Task<int?> GetTeamIdBySearchString(string searchString) 
        {
            if (searchString == null) 
            {
                return null;
            }

            searchString = searchString.ToUpper();

            var teamCache = await GetTeams();

            var team = teamCache.FirstOrDefault(it => it.Abbreviation == searchString) ?? teamCache.GetClosestMatch(searchString, it => it.Name.ToUpper());

            return team?.Id;
        }
    }
}
