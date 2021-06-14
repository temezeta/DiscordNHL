using System.Collections.Generic;

namespace NHLStats.Dtos
{
    public class RecordDto
    {
        public string StandingsType { get; set; }
        public CommonProperties League { get; set; }
        public CommonProperties Division { get; set; }
        public CommonProperties Conference { get; set; }
        public IList<TeamRecordDto> TeamRecords { get; set; }

    }
}