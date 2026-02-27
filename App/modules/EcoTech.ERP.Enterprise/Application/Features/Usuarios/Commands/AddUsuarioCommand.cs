using System;
using System.Collections.Generic;
using System.Text;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.DTOs;
using MediatR;

namespace EcoTech.ERP.Enterprise.Application.Features.Usuarios.Commands
{
    public record AddUsuarioCommand(
        string username,
        string email,
        string password,
        Guid? role_id
    ) : IRequest<UsuariosDto>;
}
