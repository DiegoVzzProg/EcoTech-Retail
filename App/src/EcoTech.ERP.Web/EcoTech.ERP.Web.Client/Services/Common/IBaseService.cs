using EcoTech.Shared.Common.Responses;

namespace EcoTech.ERP.Web.Client.Services.Common
{
    public interface IBaseService<T>
    {
        public Task<ApiResponse<List<T>>> GetAllAsync();
        public Task<ApiResponse<T>> GetByIdAsync(string id);
        public Task DeleteAsync(string id);
    }
}
