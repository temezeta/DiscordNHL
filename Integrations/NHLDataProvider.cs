using Common.Services;
using System.Net.Http;

namespace DiscordNHL.Integrations
{
    public class NHLDataProvider : BaseApiClient, INHLDataProvider
    {
        public NHLDataProvider(HttpClient client) : base(client) { }
    }
}
