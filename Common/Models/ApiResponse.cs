using System.Net.Http;

namespace Common.Models
{
    public class ApiResponse<T> where T : class
    {
        public bool IsSuccess => HttpResponseMessage.IsSuccessStatusCode;
        public HttpResponseMessage HttpResponseMessage { get; }
        public T? Data { get; set; }

        public ApiResponse(HttpResponseMessage httpResponseMessage) { HttpResponseMessage = httpResponseMessage; }
    }
}
