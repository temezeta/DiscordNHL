using System.Collections.Generic;

namespace DiscordNHL.Dtos.StatsAPI
{
    public class FranchisesDto
    {
        public string Copyright { get; set; }
        public IList<FranchiseDto> Franchises { get; set; }
    }
}
