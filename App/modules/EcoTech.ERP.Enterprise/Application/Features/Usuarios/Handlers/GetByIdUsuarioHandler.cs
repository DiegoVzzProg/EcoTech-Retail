using System;
using System.Collections.Generic;
using System.Text;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.DTOs;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.Queries;
using EcoTech.ERP.Enterprise.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcoTech.ERP.Enterprise.Application.Features.Usuarios.Handlers
{
    public class GetByIdUsuarioHandler : IRequestHandler<GetByIdUsuarioQuery, UsuariosDto?>
    {
        private readonly AppDbContext _context;

        public GetByIdUsuarioHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UsuariosDto?> Handle(GetByIdUsuarioQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _context.Usuarios
            .Include(u => u.Rol)
            .AsNoTracking()
            .Where(u => u.id == request.id)
            .Select(u => new UsuariosDto(
                u.id,
                u.username,
                u.email,
                u.Rol != null ? u.Rol.name : "Sin Rol",
                u.active,
                u.created_at
            )).FirstOrDefaultAsync(cancellationToken);

            return usuarios;
        }
    }
}
