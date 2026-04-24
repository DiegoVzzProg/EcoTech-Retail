using EcoTech.ERP.Enterprise.Application.Features.Usuarios.DTOs;
using EcoTech.ERP.Web.Client.Services.Common;
using EcoTech.Shared.Common.Responses;
using EcoTech.Shared.DTOs.Request;

namespace EcoTech.ERP.Web.Client.Services.Interfaces
{
    public interface IUsuarioService
    {
        public Task<ApiResponse<List<UsuariosDto>>> GetAllAsync();
        public Task<ApiResponse<UsuariosDto>> CreateAsync(AddUsuarioRequest command);
    }
}
