using System;

namespace NHLStats.Dtos
{
    public class GameDto : LinkProperty
    {
        public uint GamePk { get; set; }
        public string GameType { get; set; }
        public string Season { get; set; }
        public DateTime GameDate { get; set; }
        public StatusDto Status { get; set; }
        public GameTeamsDto Teams { get; set; }
        public CommonProperties Venue { get; set; }
        public LinkProperty Content { get; set; }
    }
}
