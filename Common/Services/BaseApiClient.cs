using Common.Interfaces;
using Common.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Common.Services
{
    public class BaseApiClient : IBaseApiClient
    {
        public HttpClient HttpClient { get; }

        public BaseApiClient(HttpClient client) { HttpClient = client;}

        public async Task<ApiResponse<T>> GetAsync<T>(string url) where T : class
        {
            return await CreateApiResponse<T>(await HttpClient.GetAsync(url));
        }

        public async Task<ApiResponse<T>> DeleteAsync<T>(string url) where T : class
        {
            return await CreateApiResponse<T>(await HttpClient.DeleteAsync(url));
        }

        public async Task<ApiResponse<T>> PostAsync<T>(string url, object payload) where T : class
        {
            return await CreateApiResponse<T>(await HttpClient.PostAsJsonAsync(url, payload));
        }

        public async Task<ApiResponse<T>> PutAsync<T>(string url, object payload) where T : class
        {
            return await CreateApiResponse<T>(await HttpClient.PutAsJsonAsync(url, payload));
        }

        private async Task<ApiResponse<T>> CreateApiResponse<T>(HttpResponseMessage message) where T : class
        {
            return new ApiResponse<T>(message)
            {
                Data = message.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(await message.Content.ReadAsStringAsync()) : null,
            };
        }
    }
}
