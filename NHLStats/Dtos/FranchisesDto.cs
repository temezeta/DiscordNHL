using System.Collections.Generic;

namespace NHLStats.Dtos
{
    public class FranchisesDto
    {
        public string Copyright { get; set; }
        public IList<FranchiseDto> Franchises { get; set; }
    }
}
