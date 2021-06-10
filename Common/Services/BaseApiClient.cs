using Common.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Common.Services
{
    public class BaseApiClient
    {
        private readonly HttpClient HttpClient;

        public BaseApiClient(HttpClient client) { HttpClient = client;}

        public async Task<ApiResponse<T>> GetAsync<T>(string path) {
            var response = await HttpClient.GetAsync(path);

            return await CreateApiResponse<T>(response);
        }
        public async Task<ApiResponse<T>> DeleteAsync<T>(string path) {
            var response = await HttpClient.DeleteAsync(path);

            return await CreateApiResponse<T>(response);
        }

        public async Task<ApiResponse<T>> PostAsync<T>(string path, object content) {

            var response = await HttpClient.PostAsync(path, new StringContent(JsonConvert.SerializeObject(content)));

            return await CreateApiResponse<T>(response);
        }
        public async Task<ApiResponse<T>> PutAsync<T>(string path, object content) {

            var response = await HttpClient.PutAsync(path, new StringContent(JsonConvert.SerializeObject(content)));

            return await CreateApiResponse<T>(response);
        }

        private async Task<ApiResponse<T>> CreateApiResponse<T>(HttpResponseMessage message)
        {
            return new ApiResponse<T>
            {
                IsSuccess = message.IsSuccessStatusCode,
                Data = message.IsSuccessStatusCode ? JsonConvert.DeserializeObject<T>(await message.Content.ReadAsStringAsync()) : default,
                Error = !message.IsSuccessStatusCode ? message.ReasonPhrase : null
            };
        }
    }
}
