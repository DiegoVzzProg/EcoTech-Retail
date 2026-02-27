using System;
using System.Collections.Generic;
using System.Text;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.DTOs;
using MediatR;

namespace EcoTech.ERP.Enterprise.Application.Features.Usuarios.Queries
{
    public record GetByIdUsuarioQuery(Guid id) : IRequest<UsuariosDto>;
}
