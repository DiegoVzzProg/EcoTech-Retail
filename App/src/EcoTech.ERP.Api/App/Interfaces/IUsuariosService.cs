using EcoTech.ERP.Api.App.Common.Responses;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.Commands;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EcoTech.ERP.Api.App.Interfaces
{
    public interface IUsuariosService
    {
        Task<ApiResponse<List<UsuariosDto>>> GetAll();
        Task<ApiResponse<UsuariosDto>> GetByIdUsuario(Guid id);
        Task<ApiResponse<UsuariosDto>> CreateUsuario(AddUsuarioCommand command);
    }
}
