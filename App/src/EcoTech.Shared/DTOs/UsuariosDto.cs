using System;
using System.Collections.Generic;
using System.Text;

namespace EcoTech.ERP.Enterprise.Application.Features.Usuarios.DTOs
{
    public record UsuariosDto(
        Guid id,
        string username,
        string email,
        string role_name,
        bool active,
        DateTime created_at
    );
}
