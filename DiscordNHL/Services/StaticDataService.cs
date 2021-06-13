using DiscordNHL.Dtos.StatsAPI;
using System.Collections.Generic;

namespace DiscordNHL.Services
{
    public static class StaticDataService
    {
        public static IDictionary<string, int> TeamIdByAbbreviation;

        public static IDictionary<string, int> SetTeamIds(TeamsDto teamResponse)
        {
            if(teamResponse != null && teamResponse.Teams != null)
            {
                if(TeamIdByAbbreviation == null)
                {
                    TeamIdByAbbreviation = new Dictionary<string, int>();
                }

                foreach (var team in teamResponse.Teams) {
                    TeamIdByAbbreviation.Add(team.Abbreviation, team.Id);
                }
            }

            return TeamIdByAbbreviation;
        }
    }
}
