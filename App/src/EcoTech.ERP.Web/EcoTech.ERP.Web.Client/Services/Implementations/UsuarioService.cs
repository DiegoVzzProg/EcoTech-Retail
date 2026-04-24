using System.Net.Http.Json;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.DTOs;
using EcoTech.ERP.Web.Client.Services.Common;
using EcoTech.ERP.Web.Client.Services.Interfaces;
using EcoTech.Shared.Common.Responses;
using EcoTech.Shared.DTOs.Request;

namespace EcoTech.ERP.Web.Client.Services.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        protected readonly HttpClient _http;
        private readonly string _endpoint = "usuarios";

        public UsuarioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<ApiResponse<List<UsuariosDto>>> GetAllAsync() =>
            await _http.GetFromJsonAsync<ApiResponse<List<UsuariosDto>>>($"{_endpoint}/");

        public async Task<ApiResponse<UsuariosDto>> CreateAsync(AddUsuarioRequest command)
            => await _http.GetFromJsonAsync<ApiResponse<UsuariosDto>>($"{_endpoint}/");
    }
}
