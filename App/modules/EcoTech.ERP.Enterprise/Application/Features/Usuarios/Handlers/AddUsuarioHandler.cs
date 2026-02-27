using System;
using System.Collections.Generic;
using System.Text;
using EcoTech.ERP.Enterprise.Application.Features.Common;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.Commands;
using EcoTech.ERP.Enterprise.Application.Features.Usuarios.DTOs;
using EcoTech.ERP.Enterprise.Domain.Entities;
using EcoTech.ERP.Enterprise.Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EcoTech.ERP.Enterprise.Application.Features.Usuarios.Handlers
{
    public class AddUsuarioHandler : IRequestHandler<AddUsuarioCommand, UsuariosDto>
    {
        private readonly AppDbContext _context;

        public AddUsuarioHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UsuariosDto> Handle(AddUsuarioCommand request, CancellationToken cancellationToken)
        {
            bool existeCorreo = await _context.Usuarios
                .AnyAsync(u => u.email == request.email, cancellationToken);

            if (existeCorreo)
                throw new Exception($"El correo {request.email} ya está registrado en el sistema.");

            bool existeUsername = await _context.Usuarios
                .AnyAsync(u => u.username == request.username, cancellationToken);

            if (existeUsername)
                throw new Exception($"El nombre de usuario {request.username} no está disponible.");

            string roleName = "Sin Rol";

            if (request.role_id.HasValue)
            {
                var rol = await _context.Roles.FindAsync(new object[] { request.role_id.Value }, cancellationToken);
                if (rol != null)
                {
                    roleName = rol.name;
                }
            }

            string passwordHasheada = PasswordHelper.HashPassword(request.password);

            var nuevoUsuario = new UsuariosEntity
            {
                id = Guid.NewGuid(),
                username = request.username,
                email = request.email,
                password = passwordHasheada,
                role_id = request.role_id,
                active = true,
                created_at = DateTime.Now
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync(cancellationToken);

            return new UsuariosDto(
                nuevoUsuario.id,
                nuevoUsuario.username,
                nuevoUsuario.email,
                roleName,
                nuevoUsuario.active,
                nuevoUsuario.created_at
            );
        }
    }
}
