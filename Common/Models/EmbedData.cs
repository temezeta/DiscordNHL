using System.Collections.Generic;

namespace Common.Models
{
    public class EmbedData
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }

        public IList<EmbedValue> Data { get; set; } 
    }
}
