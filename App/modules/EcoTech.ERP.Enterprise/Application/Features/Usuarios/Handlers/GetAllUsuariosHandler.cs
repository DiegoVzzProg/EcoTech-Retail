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
    public class GetAllUsuariosHandler : IRequestHandler<GetAllUsuariosQuery, List<UsuariosDto>>
    {
        private readonly AppDbContext _context;

        public GetAllUsuariosHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<UsuariosDto>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _context.Usuarios
                .Include(u => u.Rol)
                .AsNoTracking()
                .Select(u => new UsuariosDto(
                    u.id,
                    u.username,
                    u.email,
                    u.Rol != null ? u.Rol.name : "Sin Rol",
                    u.active,
                    u.created_at
                ))
                .ToListAsync(cancellationToken);

            return usuarios;
        }
    }
}
