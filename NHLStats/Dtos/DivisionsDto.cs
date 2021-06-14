using System.Collections.Generic;

namespace NHLStats.Dtos
{
    public class DivisionsDto
    {
        public string Copyright { get; set; }
        public IList<DivisionDto> Divisions { get; set;}
    }
}
