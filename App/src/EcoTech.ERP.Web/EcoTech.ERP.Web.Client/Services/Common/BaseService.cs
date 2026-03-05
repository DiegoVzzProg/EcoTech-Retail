using System.Net.Http.Json;
using EcoTech.Shared.Common.Responses;

namespace EcoTech.ERP.Web.Client.Services.Common
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly HttpClient _http;
        private readonly string _endpoint;

        public BaseService(HttpClient http, string endpoint)
        {
            _http = http;
            _endpoint = endpoint;
        }

        public async Task<ApiResponse<List<T>>> GetAllAsync() =>
            await _http.GetFromJsonAsync<ApiResponse<List<T>>>($"{_endpoint}/");

        public async Task<ApiResponse<T>> GetByIdAsync(string id) =>
            await _http.GetFromJsonAsync<ApiResponse<T>>($"{_endpoint}/{id}");

        public async Task CreateAsync(T entity) =>
            await _http.PostAsJsonAsync($"{_endpoint}/", entity);

        public async Task DeleteAsync(string id) =>
            await _http.DeleteAsync($"{_endpoint}/{id}");
    }
}
