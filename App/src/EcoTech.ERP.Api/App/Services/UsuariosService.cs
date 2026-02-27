using EcoTech.ERP.Api.App.Common.Responses;
using EcoTech.ERP.Api.App.Interfaces;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.Commands;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.DTOs;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.CodeAnalysis.CSharp.SyntaxTokenParser;

namespace EcoTech.ERP.Api.App.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly ISender _sender;

        public UsuariosService(ISender sender)
        {
            _sender = sender;
        }

        public async Task<ApiResponse<List<UsuariosDto>>> GetAll()
        {
            var result = await _sender.Send(new GetAllUsuariosQuery());
            return new ApiResponse<List<UsuariosDto>>(result);
        }

        public async Task<ApiResponse<UsuariosDto>> GetByIdUsuario(Guid id)
        {
            var result = await _sender.Send(new GetByIdUsuarioQuery(id));
            return new ApiResponse<UsuariosDto>(result);
        }

        public async Task<ApiResponse<UsuariosDto>> CreateUsuario(AddUsuarioCommand command)
        {
            var result = await _sender.Send(command);
            return new ApiResponse<UsuariosDto>(result);
        }
    }
}
