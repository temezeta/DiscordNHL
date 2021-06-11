using Common.Models;
using System.Net.Http;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IBaseApiClient
    {
        HttpClient HttpClient { get;}
        Task<ApiResponse<T>> GetAsync<T>(string url) where T : class;
        Task<ApiResponse<T>> DeleteAsync<T>(string url) where T : class;
        Task<ApiResponse<T>> PostAsync<T>(string url, object payload) where T : class;
        Task<ApiResponse<T>> PutAsync<T>(string url, object payload) where T : class;

    }
}
