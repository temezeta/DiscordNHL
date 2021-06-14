using System.Collections.Generic;

namespace NHLStats.Dtos
{
    public class PeoplesDto
    {
        public string Copyright { get; set; }
        public IList<PeopleDto> People { get; set; }
    }
}
